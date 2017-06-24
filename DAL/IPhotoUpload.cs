using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DAL
{
    interface IPhotoUpload
    {
        /// <summary>
        /// Upload photo represented as stream. 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="eventName"></param>
        /// <param name="photoName"></param>
        /// <returns></returns>
        string UploadPhoto(Stream stream, string eventName, string photoName);

        /// <summary>
        /// Upload photo represented as data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="eventName"></param>
        /// <param name="photoName"></param>
        /// <returns></returns>
        string UploadPhoto(byte[] data, string eventName, string photoName);
    }
}
