using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Models
{
    public interface IEventManagment
    {
        void AddNewUser(string userName, string email, string password);

        int AddNewEvent(string name, double latitude, double longitude,
            DateTime eventStart, DateTime eventEnd, bool isEventPublic, string AdminEmail, int radius);

        UserModel UserLogin(string email, string password);

        void UploadPhoto(System.IO.Stream photo, int eventId, string userEmail);

        List<EventModel> GetCurrentEvents(double latitude, double longitude);

        List<EventModel> GetAllEvents(string userEmail);

        EventModel GetEvent(int eventId);

        List<PictureModel> GetEventPictures(int eventId);
    }
}
