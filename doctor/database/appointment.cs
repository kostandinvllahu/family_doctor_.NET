using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace doctor.database
{
    public class appointment
    {
        public int Id { get; set; }

        public string Doctorname { get; set; }

        public string Doctoremail { get; set; }

        public string Patientname { get; set; }

        public string Service { get; set; }

        public string Comment { get; set; }

        public string Time { get; set; }

        public string Date { get; set; }

        public string EndDate { get; set; }

  }
}