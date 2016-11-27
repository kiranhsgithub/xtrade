using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace xtrade.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Buy and Sell is now Made Easy.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Have a Question or a Problem?";

            return View();
        }
    }
}