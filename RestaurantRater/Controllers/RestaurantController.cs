using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        // FIELD of model to pass to View()
        private RestaurantDbContext _db = new RestaurantDbContext();

        // GET: Restaurant/Index -- list of restaurants
        public ActionResult Index()
        {
            //          gives us our full table of restaurants (DbSet) & turns it into a list 
            return View(_db.Restaurants.ToList());
        }
    }
}