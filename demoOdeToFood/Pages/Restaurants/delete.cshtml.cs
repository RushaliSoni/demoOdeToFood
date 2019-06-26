using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoOdeToFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace demoOdeToFood.Pages.Restaurants
{
    public class deleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public demoOdeToFood.core.Restaurant Restaurant { get; set; }

        public deleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);
            restaurantData.Commit();

            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["Message"] = $"{restaurant.Name} Deleted";

            return RedirectToPage("./list");
        }
    }
}