using SchoolSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext db = new SchoolContext();
        public ActionResult Login()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(User model)
        {
                var user = db.Users.FirstOrDefault(p => p.Email == model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "The email does not exist");
                }
                else if (model.Password != user.Password)
                {
                    ModelState.AddModelError("Password", "Incorrect Password");
                }
                if (ModelState.IsValid)
                {
                    Session["UserId"] = user.UserId;
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}