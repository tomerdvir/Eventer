using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;

namespace CloudFinal.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {            
            //var user = (UserModel)TempData["User"];

            //if (user != null)
            //{
            //    var cookie = new HttpCookie("User");
            //    cookie.Values.Add("Email", user.Email);

            //    cookie.Values.Add("Name", user.UserName);

            //    cookie.Expires = DateTime.Now.AddDays(1);
                
            //    Response.SetCookie(cookie);
            //}
            return View();
        }
    }
}
