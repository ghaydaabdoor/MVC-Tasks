using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Aug13.Models;

namespace Aug13.Controllers
{
    public class HomeController : Controller
    {
        //Task 1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateCard(string imgURL, string ProductName, string ProductPrice)
        {
            Session["IMAGEURL"] = imgURL;
            Session["PRDUCTNAME"] = ProductName;
            Session["PRODUCTPRICE"] = ProductPrice;
            return View();
        }












        //Task 2
        //public ActionResult Index()
        //{
        //    List<Card> cardList;

        //    if (Session["CardList"] != null)
        //    {
        //        cardList = (List<Card>)Session["CardList"];
        //    }
        //    else
        //    {
        //        cardList = new List<Card>();
        //    }
        //    return View(cardList); // Pass the card list to the view
        //}


        //public ActionResult CreateCard()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CreateCard(string imgURL, string ProductName, string ProductPrice)
        //{
        //    List<Card> cardList;
        //    if (Session["CardList"] != null)
        //    {
        //        cardList = (List<Card>)Session["CardList"];
        //    }
        //    else
        //    {
        //        cardList = new List<Card>();
        //    }
        //    cardList.Add(new Card
        //    {
        //        ImageUrl = imgURL,
        //        ProductName = ProductName,
        //        ProductPrice = ProductPrice
        //    });
        //    Session["CardList"] = cardList;
        //    return RedirectToAction("Index");
        //}
    }
}
