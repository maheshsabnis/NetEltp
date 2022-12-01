using MVC_AppFrwk.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace MVC_AppFrwk.Controllers
{
    public class HomeController : Controller
    {
        private IServ serv;
        
        public HomeController(IServ serv)
        {
            this.serv = serv;   
        }

        public ActionResult Index()
        {
            var emps = serv.GetEmployees();
            return View(emps);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("Contact");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}