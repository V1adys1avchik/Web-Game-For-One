using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web_Ankh_Mork.Models;

namespace Web_Ankh_Mork.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Name == "Admin" && model.Password == "Admin")
                {
                    FormsAuthentication.SetAuthCookie(model.Name,true);

                    return RedirectToAction("Index", "Home");
                }
            }

            return View("Index",model);
        }

    }
}
