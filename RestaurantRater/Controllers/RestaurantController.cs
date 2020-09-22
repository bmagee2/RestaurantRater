using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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

        // GET: Restaurant/Delete/{id}
        public ActionResult Delete(int? id) // int? -- nullable id, id can now be null
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);     // user entered a bad request    
            }

            // Restaurant object    calling dbcontext Restaurants table
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();  // couldn't find restaurant
            }

            return View(restaurant);    // return restaurant matching id
        }

        // POST: Restaurant/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _db.Restaurants.Find(id);
            _db.Restaurants.Remove(restaurant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Restaurant/Edit/{id}
        public ActionResult Edit(int? id) // Get id from user
        {
            // Handle if the id is null
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Find a restaurant by id
            Restaurant restaurant = _db.Restaurants.Find(id);

            // if restaurant doesn't exist
            if (restaurant == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }

            // return restaurant and view
            return View(restaurant);
        }

        // POST: Restaurant/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
                // model state that we're given
            if (ModelState.IsValid)
            {
                // find the entry in the db based on restaurant model user is giving, access its state property & tell it it's been modified
                _db.Entry(restaurant).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);    // given back exactly what user gave (the restaurant model they're trying to update)
        }

        // GET: Restaurant/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);     // user entered a bad request    
            }

            // Restaurant object    calling dbcontext Restaurants table
            Restaurant restaurant = _db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();  // couldn't find restaurant
            }

            return View(restaurant);    // return restaurant matching id
        }
    }
}