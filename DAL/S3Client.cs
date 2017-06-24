using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

namespace DAL
{
    class S3Client : IPhotoUpload
    {
        #region Members
        
        string _accessKeyID;
        string _secretAccessKey;
        string _bucketName;

        AmazonS3Client _client;
        Amazon.RegionEndpoint _regionEndpoint;

        #endregion

        #region Ctor

        public S3Client()
        {
            Init();
        }

        #endregion

        #region Methods

        public string UploadPhoto(Stream stream, string eventName, string photoName)
        {
            PutObjectRequest s3request = new PutObjectRequest();
            s3request.WithBucketName(_bucketName + "/" + eventName)
                     .WithKey(photoName + ".jpg")
                     .WithInputStream(stream);
            s3request.WithCannedACL(S3CannedACL.PublicRead);
            s3request.Timeout = 10000;
            S3Response s3response = _client.PutObject(s3request);
            s3response.Dispose();

            // TODO
            return GetPicturePath(eventName, photoName);
        }

        public string UploadPhoto(byte[] data, string eventName, string photoName)
        {
            throw new NotImplementedException();
        }

        private void Init()
        {
            // Input check
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["AccessKey"]))
            {
                throw new ConfigurationException("Illegal configuration file - missing AWS AccessKey");
            }
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["SecretKey"]))
            {
                throw new ConfigurationException("Illegal configuration file - missing AWS SecretKey");
            }
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["BucketName"]))
            {
                throw new ConfigurationException("Illegal configuration file - missing bucket name");
            }

            _accessKeyID = ConfigurationManager.AppSettings["AccessKey"];
            _secretAccessKey = ConfigurationManager.AppSettings["SecretKey"];
            _bucketName = ConfigurationManager.AppSettings["BucketName"];
            _regionEndpoint = Amazon.RegionEndpoint.EUWest1;

            _client = new AmazonS3Client(_accessKeyID, _secretAccessKey, _regionEndpoint);
        }

        private string GetPicturePath(string eventName, string photoName)
        {
            return "https://s3-" + _regionEndpoint.SystemName + ".amazonaws.com/" + _bucketName + "/" + eventName + "/" + photoName +".jpg";
        }

        #endregion
    }
}
