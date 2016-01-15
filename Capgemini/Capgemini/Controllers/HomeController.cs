using Capgemini.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capgemini.Controllers
{
    public class HomeController : Controller
    {
        IDataManager _dataManager;

        public HomeController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}