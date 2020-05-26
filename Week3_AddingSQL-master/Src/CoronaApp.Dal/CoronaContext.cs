using CoronaApp.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaApp.Dal
{
    public class CoronaContext : DbContext
    {
        public DbSet<Patient> Patient { get; set; }
    }
}
