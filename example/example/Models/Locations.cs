using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace example.Models
{
    public class Locations
    {
        public string PatientID { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Location { get; set; }

        public string City { get; set; }

        public Locations()
        {

        }
        
        public Locations(string patientID,DateTime startDate, DateTime endDate,string location,string city)
        {
            this.PatientID = patientID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Location = location;
            this.City = city;
        }
    }

    

}
