using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Lang { get; set; }
        public double Lat { get; set; }
        public int Radius { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public bool IsPublic { get; set; }
        public string OwnerEmail { get; set; }
        public List<PictureModel> Pictures { get; set; }       

        public EventModel()
        {
        }

        public EventModel(int id, string ownerEmail, string name, double lang, double lat, int radius, string start, string end,
            bool isPublic, List<PictureModel> pictures)
        {
            this.Id = id;
            this.OwnerEmail = ownerEmail;
            this.Name = name;
            this.Lang = lang;
            this.Lat = lat;
            this.Radius = radius;
            this.Start = start;
            this.End = end;
            this.IsPublic = isPublic;
            this.Pictures = pictures;
        }
    }
}
