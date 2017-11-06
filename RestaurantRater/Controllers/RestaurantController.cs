using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static RestaurantRater.Models.Restaurant;

namespace RestaurantRater.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        private RestaurantDBContext db = new RestaurantDBContext();

        //GET: Restaurants
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        //GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        //Post: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestauraintID,Name")] Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }
    }
}