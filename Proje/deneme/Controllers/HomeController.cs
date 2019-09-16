using deneme.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace deneme.Controllers
{
    public class HomeController : Controller
    {
        MvcFormDbEntities_ db = new MvcFormDbEntities_();
        public ActionResult Index()
        {
            
            return View(db.Users.ToList());
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

       public ActionResult Create(User userData)
        {
            db.Users.Add(userData);
            db.SaveChanges();
            return View();

        }

        [HttpGet]
        public ActionResult Delete(int ?id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User userDetail = db.Users.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            User userId = db.Users.Find(id);
            db.Users.Remove(userId);
            db.SaveChanges();
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User userDetail = db.Users.Find(id);
            if (userDetail == null)
            {
                return HttpNotFound();
            }
            return View(userDetail);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include ="id,name,surname,age,jdate")] User userDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDetail);
        }
    }
}