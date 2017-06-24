using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IRepositoryManagment
    {
        /// <summary>
        /// Add new user to database
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        void AddNewUser(string userName, string email, string password);

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
        /// <param name="radius"></param>
        /// <returns>Id of the newly created event</returns>
        int AddNewEvent(string name, double latitude, double longitude,
            DateTime eventStart, DateTime eventEnd, bool isEventPublic, string AdminEmail, int radius);

        Users UserLogin(string email, string password);

        /// <summary>
        /// Upload photo to event.
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="eventId"></param>
        /// <param name="userEmail"></param>
        void UploadPhoto(System.IO.Stream photo, int eventId, string userEmail);

        /// <summary>
        /// Get a list of active events
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        List<Events> GetCurrentEvents(double latitude, double longitude);

        /// <summary>
        /// Get all albums by specific user
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        List<Events> GetAllEvents(string userEmail);

        /// <summary>
        /// Get all pictures from specific event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        List<Pictures> GetEventPictures(int eventId);

        /// <summary>
        /// Get specific event
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Events GetEvent(int eventId);
    }
}
