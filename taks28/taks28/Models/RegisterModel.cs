using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace taks28.Models
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int USER_TYPE { get; set; }

        public string MODE { get; set; }
       // public string userSession { get { return session["userid"]; } }
    }
}