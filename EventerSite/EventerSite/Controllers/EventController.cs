using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BL;

namespace CloudFinal.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        private static IEventManagment _eventManagment = new EventManagment();
        public ActionResult View(int id)
        {
            // load event by event ID
            var eventModel = _eventManagment.GetEvent(id);
                        
            return View("View", eventModel);
        }

        //
        // GET: /Event/Details/5

        public ActionResult List(int id)
        {
            return View();
        }

        public ActionResult Add()
        {
            var user = (UserModel)Session["User"];
            var model = new EventModel();
            model.OwnerEmail = user.Email;

            return View("Add", model);
        }
        
        //
        // POST: /Event/Add

        [HttpPost]
        public ActionResult Add(EventModel model)
        {
            try
            {
                // TODO: Add model to DAL
                var newEventId = _eventManagment.AddNewEvent(
                    model.Name, model.Lat, model.Lang, DateTime.Parse(model.Start), DateTime.Parse(model.End),
                    model.IsPublic, model.OwnerEmail, model.Radius);

                return RedirectToAction("View", new { id = newEventId });
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult ListEventsByLocation(double lat, double lng)
        {
            var events = _eventManagment.GetCurrentEvents(lat, lng);
            //var list = new List<object>() { 
            //    new {name = "a", id = 0}, 
            //    new {name = "b", id = 1} };

            var list = events.Select(ev => new { name = ev.Name, id = ev.Id });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ListMyEvents()
        {
            var email = ((UserModel)Session["User"]).Email;
            var events = _eventManagment.GetAllEvents(email);
            
            var list = events.Select(ev => new { name = ev.Name, id = ev.Id });
            return Json(list, JsonRequestBehavior.AllowGet);            
        }

        [HttpPost]
        public ActionResult UploadPic(FormCollection collection)
        {
            var stream = Request.Files["uploadPic"].InputStream;
            int eventId = int.Parse(collection["eventId"]);
            _eventManagment.UploadPhoto(stream, eventId, collection["OwnerEmail"]);

            return RedirectToAction("View", new { id = eventId});
        }
    }
}
