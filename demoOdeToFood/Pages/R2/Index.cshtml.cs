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
    public class IndexModel : PageModel
    {
        private readonly demoOdeToFood.Data.demoOdeToFoodDbContext _context;

        public IndexModel(demoOdeToFood.Data.demoOdeToFoodDbContext context)
        {
            _context = context;
        }

        public IList<demoOdeToFood.core.Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
