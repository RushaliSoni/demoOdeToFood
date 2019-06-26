using demoOdeToFood.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoOdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent:ViewComponent
    {
        private readonly IRestaurantData restaurantdata;

        public RestaurantCountViewComponent(IRestaurantData restaurantdata)
        {
            this.restaurantdata = restaurantdata;
        }

        public IViewComponentResult Invoke()
        {

            var count = restaurantdata.GetCountOfRestaurants();
            return View(count);


        }

    }
}
