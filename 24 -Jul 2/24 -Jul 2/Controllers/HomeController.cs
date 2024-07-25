using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _24_July.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Profile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginMethod()
        {
            string email = Request["email"];
            Session["Email"] = email;
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return View("Login");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Feedback details";
            string fname = Request["fname"];
            string lname= Request["lname"];
            string email= Request["email"];
            string phone= Request["phone"];
            string gender = Request["gender"];
            string subject = Request["subject"];
            string message= Request["message"];
            ViewBag.FName = fname;
            ViewBag.LName = lname;
            ViewBag.Email = email;
            ViewBag.Phone = phone;
            ViewBag.Gender = gender;
            ViewBag.Subject = subject;
            ViewBag.Message = message;

            return View();
        }


    }
}