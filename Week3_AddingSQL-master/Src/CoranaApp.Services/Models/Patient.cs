﻿using System.Collections.Generic;

namespace CoronaApp.Services.Models
{
    public class Patient
    {
        public string PatientID { get; set; }

        public List<Location> LocationsList { get; set; }


    }
}