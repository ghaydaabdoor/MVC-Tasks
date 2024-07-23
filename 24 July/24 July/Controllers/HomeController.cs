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

        public ActionResult Form()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Info()
        {
            ViewBag.Message = "Feedback details";
            string fname = Request["fname"];
            string lname= Request["lname"];
            string email= Request["email"];
            string phone= Request["phone"];
            string gender = Request["gender"];
            string subject = Request["subject"];
            ViewBag.FName = fname;
            ViewBag.LName = lname;
            ViewBag.Email = email;
            ViewBag.Phone = phone;
            ViewBag.Gender = gender;
            ViewBag.Subject = subject;

            return View();
        }


    }
}