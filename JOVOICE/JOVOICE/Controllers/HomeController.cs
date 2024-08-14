using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JOVOICE.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult candMain()
        {
            return View();
        }
        public ActionResult candMain2()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public ActionResult debateForm()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}