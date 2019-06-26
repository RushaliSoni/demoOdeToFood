using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demoOdeToFood.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using demoOdeToFood.core;
using Microsoft.Extensions.Logging;

namespace demoOdeToFood.Pages.Restaurant
{
    public class RestaurantModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;
        private readonly ILogger<RestaurantModel> logger;

        public string Message{ get; set; }
        public IEnumerable<demoOdeToFood.core.Restaurant> Restaurants{ get; set; }
        [BindProperty (SupportsGet =true)]
        public string SearchTearm { get; set; }
        

        public RestaurantModel(IConfiguration config ,IRestaurantData restaurantData
            ,ILogger<RestaurantModel> logger)
        {
            this.config = config;
            this.restaurantData = restaurantData;
            this.logger = logger;
        }
        
       

        public void OnGet()
        {
            logger.LogError("Execution ListModel");
            Message = config["Message"];
            Restaurants = restaurantData.GetRestaurantsByName(SearchTearm);
        }
    }
}