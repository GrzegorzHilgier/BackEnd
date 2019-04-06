using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;


namespace WebApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext( DbContextOptions <ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Vessel> Vessel { get; set; }
    }

}
