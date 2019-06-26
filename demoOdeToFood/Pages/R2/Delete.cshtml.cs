using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using demoOdeToFood.Data;
using demoOdeToFood.core;

namespace demoOdeToFood.Pages.R2
{
    public class DeleteModel : PageModel
    {
        private readonly demoOdeToFood.Data.demoOdeToFoodDbContext _context;

        public DeleteModel(demoOdeToFood.Data.demoOdeToFoodDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public demoOdeToFood.core.Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FindAsync(id);

            if (Restaurant != null)
            {
                _context.Restaurants.Remove(Restaurant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
