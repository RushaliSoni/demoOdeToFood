using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace demoOdeToFood.core
{
    public class Restaurant
    {
        public int id { get; set; }
        [Required , StringLength(80)]
        public String Name { get; set; }
        [Required, StringLength(255)]
        public String Location { get; set; }
        //public String WebSite { get; set; }
        public CuisineType cuisine { get; set; }
        

    }
}
