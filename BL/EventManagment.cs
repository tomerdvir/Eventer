using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BL
{
    public class EventManagment: IEventManagment
    {
        DAL.RepositoryManagment dal = DAL.RepositoryManagment.GetInstance;

        #region Methods

        #region IEventManagment methods

        public void AddNewUser(string userName, string email, string password)
        {
            dal.AddNewUser(userName, email, password);
        }

        public int AddNewEvent(string name, double latitude, double longitude, DateTime eventStart, DateTime eventEnd, bool isEventPublic, string AdminEmail, int radius)
        {
            return dal.AddNewEvent(name, latitude, longitude, eventStart, eventEnd, isEventPublic, AdminEmail, radius);
        }

        public UserModel UserLogin(string email, string password)
        {
            var user = dal.UserLogin(email, password);
            if (user == null)
            {
                return null;
            }

            return new UserModel(user.Email, user.UserName, user.Password); 
        }

        public void UploadPhoto(System.IO.Stream photo, int eventId, string userEmail)
        {
            dal.UploadPhoto(photo, eventId, userEmail);
        }

        public List<EventModel> GetCurrentEvents(double latitude, double longitude)
        {
            var currEvents = dal.GetCurrentEvents(latitude, longitude);

            return currEvents.Select(e => CreateEventFromDAL(e)).ToList();
        }

        public List<EventModel> GetAllEvents(string userEmail)
        {
            var allEvents = dal.GetAllEvents(userEmail);

            return allEvents.Select(e => CreateEventFromDAL(e)).ToList();
        }

        public EventModel GetEvent(int eventId)
        {
            var e = dal.GetEvent(eventId);

            return CreateEventFromDAL(e);
        }

        public List<PictureModel> GetEventPictures(int eventId)
        {
            var pics = dal.GetEventPictures(eventId);

            return pics.Select(p => CreatePictureFromDAL(p)).ToList();
        }

        #endregion

        private PictureModel CreatePictureFromDAL(Pictures p)
        {
            return new PictureModel(p.Picture_Id, p.User_Email, p.Picture_Path, p.Event_Id);
        }

        private EventModel CreateEventFromDAL(Events e)
        {
            return new EventModel(e.Event_Id, e.Admin_Email, e.Name, e.Longitude, e.Latitude, e.Radius,
                e.Event_Start.ToString(), e.Event_End.ToString(), e.IsEventPublic,
                e.Pictures == null ? null : e.Pictures.Select(p => CreatePictureFromDAL(p)).ToList());
        }

        #endregion
    }
}
