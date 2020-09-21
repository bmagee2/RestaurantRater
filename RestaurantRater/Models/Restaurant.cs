using System;
using System.Collections.Generic;
using System.Data.Entity;   // added for DbContext
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    public class Restaurant // this is our Entity -- gets stored in the db
    {
        // COLUMNS FOR THE TABLE
        public int RestaurantId { get; set; }   // PRIMARY KEY FOR TABLE
        public string Name { get; set; }
        public string Address { get; set; }
        public int Rating { get; set; }
    }

    public class RestaurantDbContext : DbContext    // snapshot of server/db 
    {
        // collection of Restaurant objects
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}