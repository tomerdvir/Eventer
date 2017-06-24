using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryManagment : IRepositoryManagment
    {
        #region Members

        const int R = 6371;

        private static RepositoryManagment _instance;
        private eventerEntities _photosEntity;
        private IPhotoUpload _photoUploader;

        #endregion

        #region Ctor

        private RepositoryManagment()
        {
            _photosEntity = new eventerEntities();
            _photoUploader = new S3Client();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get instance of PhotosSharingDal.
        /// </summary>
        public static RepositoryManagment GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RepositoryManagment();
                }

                return _instance;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add new user to database.
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        public void AddNewUser(string userName, string email, string password)
        {
            // Create new user
            Users user = new Users();
            user.Email = email;
            user.Password = password;
            user.UserName = userName;

            // Add to db
            lock (_photosEntity)
            {
                _photosEntity.Users.Add(user);
            }

            _photosEntity.SaveChanges();
        }

        /// <summary>
        /// Create new event.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="eventStart"></param>
        /// <param name="eventEnd"></param>
        /// <param name="isEventPublic"></param>
        /// <param name="AdminEmail"></param>
        public int AddNewEvent(string name, double latitude, double longitude, DateTime eventStart, DateTime eventEnd, bool isEventPublic, string AdminEmail, int radius)
        {
            Events newEvent = new Events();
            newEvent.Name = name;
            newEvent.Latitude = latitude;
            newEvent.Longitude = longitude;
            newEvent.Event_Start = eventStart;
            newEvent.Event_End = eventEnd;
            newEvent.IsEventPublic = isEventPublic;
            newEvent.Admin_Email = AdminEmail;
            newEvent.Radius = radius;

            // Add to db
            lock (_photosEntity)
            {
                _photosEntity.Events.Add(newEvent);
            }

            _photosEntity.SaveChanges();
            return newEvent.Event_Id;
        }

        /// <summary>
        /// Upload photo to event.
        /// </summary>
        /// <param name="picturePath"></param>
        /// <param name="eventId"></param>
        /// <param name="userEmail"></param>
        public void UploadPhoto(System.IO.Stream photo, int eventId, string userEmail)
        {
            Pictures picture = new Pictures();
            string eventName = GetEventName(eventId);
            picture.Picture_Path = _photoUploader.UploadPhoto(photo, eventName, Guid.NewGuid().ToString());
            picture.Event_Id = eventId;
            picture.User_Email = userEmail;

            // Add to db
            lock (_photosEntity)
            {
                _photosEntity.Pictures.Add(picture);
            }

            _photosEntity.SaveChanges();
        }

        /// <summary>
        /// Get list of events that happening right now and around current location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public List<Events> GetCurrentEvents(double latitude, double longitude)
        {
            var events = (from b in _photosEntity.Events
                         where b.Event_Start < DateTime.Now
                         where b.Event_End > DateTime.Now
                         select b)
                         .AsEnumerable<Events>()
                         .Where(x => x.Radius > GetDistance(latitude, longitude, x.Latitude, x.Longitude));

            return events.ToList<Events>();
        }

        /// <summary>
        /// Get list of public albums that the specific user upload a photo to.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public List<Events> GetAllEvents(string userEmail)
        {
            var events = from b in _photosEntity.Events
                         where b.IsEventPublic == true
                         where b.Users.Email == userEmail
                         select b;


            return events.ToList<Events>();
        }

        /// <summary>
        /// Get a list of photos from specific event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public List<Pictures> GetEventPictures(int eventId)
        {
            var pictures = from b in _photosEntity.Pictures
                           where b.Event_Id == eventId
                           select b;

            return pictures.ToList<Pictures>();
        }

        /// <summary>
        /// Return user login information
        /// Return null if user doesn't exists
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Users UserLogin(string email, string password)
        {
            var users = from b in _photosEntity.Users
                        where b.Email == email
                        where b.Password == password
                        select b;

            if (users.Count<Users>() == 0)
            {
                return null;
            }

            return users.First();
        }

        /// <summary>
        /// Get specific event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Events GetEvent(int eventId)
        {
            var currEvent = from b in _photosEntity.Events
                        where b.Event_Id == eventId
                        select b;

            if (currEvent.Count<Events>() == 0)
            {
                return null;
            }

            return currEvent.First();
        }

        private string GetEventName(int eventID)
        {
            var events = from b in _photosEntity.Events
                        where b.Event_Id == eventID
                        select b.Name;

            return events.Single<string>();
            //return events.First<string>();
        }

        private double GetDistance(double currLat, double currLng, double eventLat, double eventLng)
        {
            currLat = DegreeToRadian(currLat);
            currLng = DegreeToRadian(currLng);
            eventLat = DegreeToRadian(eventLat);
            eventLng = DegreeToRadian(eventLng);

            var x = (currLng - eventLng) * Math.Cos((currLat + eventLat) / 2);
            var y = (currLng - eventLng);
            return Math.Sqrt(x * x + y * y) * R * 1000;
        }

        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        #endregion
    }
}