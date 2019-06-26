﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace demoOdeToFood.Data
{
    public class demoOdeToFoodDbContext : DbContext
    {
        public demoOdeToFoodDbContext(DbContextOptions<demoOdeToFoodDbContext> options)
              :base(options)
        {

        }
        public DbSet<demoOdeToFood.core.Restaurant> Restaurants { get; set; }
    }
}
