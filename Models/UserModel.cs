using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }


        public UserModel()
        {
            this.UserName = "username";
        }

        public UserModel(string email, string userName, string password)
        {
            this.Email = email;
            this.UserName = userName;
            this.Password = password;
        }
    }
}
