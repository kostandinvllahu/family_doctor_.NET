using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doctor.database
{
    public class Doctor
    {
        public int Id { get; set; }

        public string fullname { get; set; }

        public string email { get; set; }

        public string username { get; set; }

        public string password { get; set; }
    }
}