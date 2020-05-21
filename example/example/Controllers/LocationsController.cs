using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using example.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace example.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<Locations> LocationsList = new List<Locations>
        {
            new Locations{ PatientID = "123466666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Heifa", Location = "Restaurant" },
            new Locations{ PatientID = "123466666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Givat-Zeev",  Location = "Office" },
            new Locations{ PatientID = "123486666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Tel-Aviv", Location = "Sea" },
            new Locations{ PatientID = "123496666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Miron", Location = "Rashb" },
            new Locations{ PatientID = "123506666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Beitar", Location = "Park" },
            new Locations{ PatientID = "123516666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Beit-Shemesh",Location = "Garden" },
            new Locations{ PatientID = "123526666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem",Location = "Shul" },
            new Locations{ PatientID = "123526666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem", Location = "Shul" },
            new Locations{ PatientID = "123536666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Elad",Location = "Super" },
            new Locations{ PatientID = "123546666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Zfat", Location = "Kinder-Garden" },
            new Locations{ PatientID = "123556666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem",Location = "Market" },
            new Locations{ PatientID = "123566666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Raht",Location =  "Park" },
            new Locations{ PatientID = "123576666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Givat-Zeev",Location =  "bus-stop" },
            new Locations{ PatientID = "123586666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Jerusalem", Location = "Market" },
            new Locations{ PatientID = "123596666", StartDate = new DateTime(2020,03,01, 12,00,00),EndDate = new DateTime(2020,03,01, 12,00,00),City = "Arad", Location = "Dead-Sea" }
        };

        private readonly ILogger<LocationsController> _logger;

        public LocationsController(ILogger<LocationsController> logger)
        {
            _logger = logger;
        }

        

        public List<Locations> GetPatientLocations(string patientId)
        {
            //List<Locations> patientLocations = new List<Locations>();

            //for (int i = 0; i < LocationsList.Count; i++)
            //{
            //    if (LocationsList[i].PatientID == patientId)
            //    {
            //        patientLocations.Add(LocationsList[i]);
            //    }
            //}
            List<Locations> patientLocations = LocationsList.FindAll(l => l.PatientID == patientId).ToList();
            if (patientLocations == null)
            {
                return null;
            }
            return patientLocations;
        }

        //[HttpGet("{patientId}")]
        [HttpGet]
        public async Task<List<Locations>> GetLocationsById([FromQuery] string patientId)
        {
            List<Locations> patientLocations = await Task.Run(() => GetPatientLocations(patientId));
            return patientLocations;
        }

        [HttpPost]
        public async Task AddLocation([FromBody] List<Locations> newLocations)
        {
            for (int i = 0; i < newLocations.Count; i++)
            {
               LocationsList.Add(newLocations[i]);
            }

        }

       [HttpDelete]
        public async Task<string> DeleteLocation([FromBody] Locations location)
        {

            Locations locationToDelete = LocationsList.Find(l => l.PatientID == location.PatientID &&
            l.StartDate == location.StartDate &&
            l.EndDate == location.EndDate &&
            l.Location == location.Location &&
            l.City == location.City);

            if (LocationsList.Remove(locationToDelete))
            {
                return "Delete patient succeded";
            }

            return "The patient is not exist";
            
        }
    }
}


