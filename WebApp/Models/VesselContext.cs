using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;


namespace WebApp.Models
{
    public class VesselContext : DbContext
    {
        public VesselContext( DbContextOptions <VesselContext> options) : base(options)
        {

        }

        public DbSet<Vessel> Vessel { get; set; }
    }

}
