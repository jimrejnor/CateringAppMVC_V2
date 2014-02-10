using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CateringApplication.Core;
using CateringApplication.Core.Interfaces;
using CateringApplication.Core.Models;

namespace CateringApplication.Web.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        public ViewResult View(int id, string sortOrder)
        {
            ViewBag.TownID = id;

            RestaurantListViewModel restaurantListView = _restaurantService.GetAllInTown(id);

            // sorting when clicked on "Restaurant"
            ViewBag.SortNameParam = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            switch (sortOrder)
            {
                case "name_desc":
                    restaurantListView.Restaurants = restaurantListView.Restaurants.OrderByDescending(r => r.Name);
                    break;
                default:
                    restaurantListView.Restaurants = restaurantListView.Restaurants.OrderBy(r => r.Name);
                    break;
            }

            return View(restaurantListView);
        }

        //
        // GET: /Restaurant/Create
        // create new restaurant for specific, currently selected town
        public ActionResult Create(int id)
        {
            RestaurantViewModel restaurantView = new RestaurantViewModel();
            restaurantView.TownID = id;

            return View(restaurantView);
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                if (_restaurantService.Insert(restaurant))
                {
                    return RedirectToAction("View", new { id = restaurant.TownID });
                }
            }

            return View(restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            RestaurantViewModel restaurantView = _restaurantService.GetByID(id);
            return View(restaurantView);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestaurantViewModel restaurant)
        {
            if (ModelState.IsValid)
            {
                if (_restaurantService.Update(restaurant))
                {
                    return RedirectToAction("View", new { id = restaurant.TownID });
                }
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id)
        {
            RestaurantViewModel restaurantView = _restaurantService.GetByID(id);
            return View(restaurantView);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int TownID, int id)
        {
            if (_restaurantService.Delete(id))
            {
                return RedirectToAction("View", new { id = TownID });
            }

            RestaurantViewModel restaurantView = _restaurantService.GetByID(id);
            return View(restaurantView);
        }

        protected override void Dispose(bool disposing)
        {
            _restaurantService.Dispose();
            base.Dispose(disposing);
        }

        /*
        private IUnitOfWork _unitOfWork;

        public RestaurantController()
            : this(new UnitOfWork())
        {
        }

        public RestaurantController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ViewResult Index(string townName)
        {
            // store townName in ViewBag so we can show which is current Town
            ViewBag.CurrentTown = townName;
            var restaurants = _unitOfWork.RestaurantRepository.Get(filter: r => r.Town.Name == townName);
            return View(restaurants.ToList());
        }

        //
        // GET: /Restaurant/Create

        // create new restaurant for specific, currently selected town
        public ActionResult Create(string townName)
        {
            ViewBag.CurrentTown = townName;

            var town = _unitOfWork.TownRepository.Get(filter: t => t.Name == townName).FirstOrDefault();
            Restaurant restaurant = new Restaurant();
            restaurant.Town = town;
            restaurant.TownID = town.TownID;

            return View(restaurant);
        }

        //
        // POST: /Restaurant/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RestaurantRepository.Insert(restaurant);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        //
        // GET: /Restaurant/Edit/5

        public ActionResult Edit(int id)
        {
            Restaurant restaurant = _unitOfWork.RestaurantRepository.GetByID(id);
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.RestaurantRepository.Update(restaurant);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        //
        // GET: /Restaurant/Delete/5

        public ActionResult Delete(int id)
        {
            Restaurant restaurant = _unitOfWork.RestaurantRepository.GetByID(id);
            return View(restaurant);
        }

        //
        // POST: /Restaurant/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _unitOfWork.RestaurantRepository.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
         */
    }
}