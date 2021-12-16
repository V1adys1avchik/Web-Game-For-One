using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Ankh_Mork.DB;
using Web_Ankh_Mork.DB.Entity;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = Properties.Resources.Welcome
                .Split(new string[] { "\n\n" }, StringSplitOptions.None);

            return View();
        }

        public ActionResult Rules()
        {
            ViewBag.Message = Properties.Resources.Rules
                            .Split(new string[]{"\n\n"},StringSplitOptions.None);
            
            return View();
        }
    }
}