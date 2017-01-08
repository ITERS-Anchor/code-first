using LoginRegister.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LoginRegister.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (myDbContext db = new myDbContext())
            {
                return View(db.userAccount.ToList());
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (myDbContext db = new myDbContext())
            {
                userAccount u = db.userAccount.FirstOrDefault(x=>x.UserID==id);
                ViewData.Model = u;
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(userAccount u)
        {
            using (myDbContext db = new myDbContext())
            {
                db.userAccount.Attach(u);
                db.Entry(u).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int id)
        {
            using (myDbContext db = new myDbContext())
            {
                userAccount u = db.userAccount.Single(x => x.UserID == id);
                db.userAccount.Remove(u);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(userAccount user)
        {
            if (ModelState.IsValid)
            {
                using (myDbContext db = new myDbContext())
                {
                    db.userAccount.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.msg = user.FirstName + " Register successful";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(userAccount user)
        {
            using (myDbContext db = new myDbContext())
            {
                var u = db.userAccount.FirstOrDefault(x => x.UserName == user.UserName);
                if (u == null || u.Password != user.Password)
                {
                    //ViewBag.msg = "Wrong UserName or Password!";
                    ModelState.AddModelError("", "Wrong UserName or Password!");
                }
                else
                {
                    Session["UserId"] = user.UserName;
                    Session["UserName"] = user.UserName;
                    return Redirect(Url.Action("Index", "Home"));
                }
            }

            return View();
        }
    }

    //public ActionResult delete(int id)
    //{
    //    
    //    return Redirect(Url.Action("Index", "Home"));
    //    //return 
    //}
}