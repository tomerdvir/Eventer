using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BL;

namespace CloudFinal.Controllers
{
    public class AccountController : Controller
    {
        private static IEventManagment _eventManagment = new EventManagment();
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View("Account");
        }        

        //
        // POST: /Account/Login

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var userModel = _eventManagment.UserLogin(collection["email"], collection["password"]);

                if (userModel != null)
                {
                    Session.Add("User", userModel);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Index();
                }
            }
            catch
            {
                return Index();
            }
        }

        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Create user                
                var userModel = new UserModel()
                {
                    UserName = collection["newUserName"],
                    Email = collection["newEmail"],
                    Password = collection["newPassword"]
                };

                _eventManagment.AddNewUser(userModel.UserName, userModel.Email, userModel.Password);

                Session.Add("User", userModel);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }        
    }
}
