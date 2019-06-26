using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using demoOdeToFood.core;
using demoOdeToFood.Data;

namespace demoOdeToFood.Pages.Restaurants
{
    
    public class detailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        [TempData]
        public string Message { get; set; }
        public detailModel(IRestaurantData restaurantData)
        {
           this.restaurantData = restaurantData;
        }
        public demoOdeToFood.core.Restaurant Restaurant { get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            // Restaurant = new demoOdeToFood.core.Restaurant();
            //Restaurant.id = restaurantId;
            Restaurant = restaurantData.GetById(restaurantId);
            if (Restaurant == null)
            {
                return RedirectToPage("./Not Found");
            }
            return Page();



        }
    }
}