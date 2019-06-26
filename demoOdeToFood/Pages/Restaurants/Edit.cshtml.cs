using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoOdeToFood.core;
using demoOdeToFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace demoOdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        [BindProperty]
        public demoOdeToFood.core.Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisine { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisine = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);

            }
            else {
                Restaurant = new demoOdeToFood.core.Restaurant();   
             }
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisine = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }
            if (Restaurant.id > 0)
            {
                restaurantData.Update(Restaurant);
            }
            else
            {
                restaurantData.Add(Restaurant);
            }
           
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved";
            return RedirectToPage("./detail", new { restaurantId = Restaurant.id });
            //Restaurant= restaurantData.Update(Restaurant);
            //restaurantData.Commit();
        }
    }
}