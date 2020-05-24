using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Services.Models
{
   public class AsDB
    {
        public static List<Location> LocationsList1 = new List<Location>
        {
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Tel-Aviv", Locations = "Sea" },

        };

        public static List<Location> LocationsList2 = new List<Location>
        {
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Heifa", Locations = "Restaurant" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Givat-Zeev",  Locations = "Office" },

        };

        public static List<Location> LocationsList3 = new List<Location>
        {
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Beitar", Locations = "Park" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Zfat", Locations = "Kinder-Garden" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem",Locations = "Market" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Raht",Locations =  "Park" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Givat-Zeev",Locations =  "bus-stop" },

        };

        public static List<Location> LocationsList4 = new List<Location>
        {
        new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Beit-Shemesh",Locations = "Garden" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem",Locations = "Shul" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem", Locations = "Shul" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Elad",Locations = "Super" },
        };

        public static List<Location> LocationsList5 = new List<Location>
         {
          new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem", Locations = "Market" },
            new Location{ StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Arad", Locations = "Dead-Sea" }
         };

        public static List<Patient> PatientList = new List<Patient>
        {
            new Patient{ PatientID = "123456789" , LocationsList=LocationsList1},
            new Patient{ PatientID = "123456788" , LocationsList=LocationsList2},
            new Patient{ PatientID = "123456777" , LocationsList=LocationsList3},
            new Patient{ PatientID = "123456666" , LocationsList=LocationsList4},
            new Patient{ PatientID = "123455555" , LocationsList=LocationsList5}
    };

    }
}
