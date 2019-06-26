using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using demoOdeToFood.Data;
using demoOdeToFood.core;

namespace demoOdeToFood.Pages.R2
{
    public class CreateModel : PageModel
    {
        private readonly demoOdeToFood.Data.demoOdeToFoodDbContext _context;

        public CreateModel(demoOdeToFood.Data.demoOdeToFoodDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public demoOdeToFood.core.Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Restaurants.Add(Restaurant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}