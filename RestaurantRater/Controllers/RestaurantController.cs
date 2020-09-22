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

        // GET: Restaurant/Create -- get our view
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]  // ONLY A POST METHOD
        [ValidateAntiForgeryToken]  
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);    // add new restaurant
                _db.SaveChanges();          // anything added, save to the db
                return RedirectToAction("Index");   // redirect to the Index (list of restaurants)
            }

            return View(restaurant);    // return model (the filled out form) & give it back -- doesn't clear already filled out form
        }
    }
}