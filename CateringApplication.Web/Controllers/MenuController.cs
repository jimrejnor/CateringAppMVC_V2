using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CateringApplication.Core;
using CateringApplication.Core.Interfaces;
using CateringApplication.Core.Models;

namespace CateringApplication.Web.Controllers
{
    public class MenuController : Controller
    {
       private IMenuService _menuService;

       public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public ViewResult Index()
        {
            return View(_menuService.GetAll());
        }

        //
        // GET: /Menu/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Menu/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MenuViewModel menu)
        {
            if (ModelState.IsValid)
            {
                if (_menuService.Insert(menu))
                {
                    return RedirectToAction("Index");
                }
            }

            return View(menu);
        }

        //
        // GET: /Menu/Edit/5

        public ActionResult Edit(int id)
        {
            MenuViewModel menuView = _menuService.GetByID(id);
            return View(menuView);
        }

        //
        // POST: /Menu/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MenuViewModel menu)
        {
            if (ModelState.IsValid)
            {
                if (_menuService.Update(menu))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(menu);
        }

        //
        // GET: /Menu/Delete/5

        public ActionResult Delete(int id)
        {
            MenuViewModel menuView = _menuService.GetByID(id);
            return View(menuView);
        }

        //
        // POST: /Menu/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (_menuService.Delete(id))
            {
                return RedirectToAction("Index");
            }

            MenuViewModel menuView = _menuService.GetByID(id);
            return View(menuView);
        }


        protected override void Dispose(bool disposing)
        {
            _menuService.Dispose();
            base.Dispose(disposing);
        }
    }
}
