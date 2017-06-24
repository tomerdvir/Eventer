using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class PictureModel
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string UserEmail { get; set; }
        public int EventId { get; set; }


        public PictureModel()
        {
        }

        public PictureModel(int id, string userEmail, string url, int eventID)
        {
            this.Id = id;
            this.URL = url;
            this.EventId = eventID;
            this.UserEmail = userEmail;
        }
    }
}
