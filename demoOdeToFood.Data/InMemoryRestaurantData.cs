using demoOdeToFood.core;
using System;
using System.Linq;
using System.Collections.Generic;

namespace demoOdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;



        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {id=1,Name= "Rangoli" , Location="Gujarat", cuisine=CuisineType.Indian},
                new Restaurant {id=2,Name= "Sankalp" , Location="Japan (Kunfooo)", cuisine=CuisineType.japan},
                new Restaurant {id=3,Name= "Thalai" , Location="Chandi Chok to china", cuisine=CuisineType.China}
            };
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.id = restaurants.Max(r => r.id) + 1;
            return newRestaurant;
        }
        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.id == updatedRestaurant.id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.cuisine = updatedRestaurant.cuisine;

            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }

       

        public IEnumerable<Restaurant> GetRestaurantsByName(string name =null)
        {
            return from r in restaurants
                   where string .IsNullOrEmpty(name) ||  r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
                
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();

        }
    }
}
