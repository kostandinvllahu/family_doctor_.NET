using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doctor.database
{
    public class Users
    {
        public int id { get; set; }

        public string fullname { get; set; }

        public string email { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string idcard { get; set; }

        public string address { get; set; }

        public string addresstwo { get; set; }

        public string phone { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zipcode { get; set; }

        public string doctor { get; set; }

    }
}