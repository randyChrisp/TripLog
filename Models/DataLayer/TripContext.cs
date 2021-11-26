using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripLog.Models;

namespace TripLog.Models
{
    public class TripContext: DbContext
    {
        public TripContext(DbContextOptions<TripContext> options) : base(options)
        { }

        public DbSet<TripsLog> Trips { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }
        public DbSet<Activity> Activities { get; set;}
        public DbSet<TripActivity> TripActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TripConfig());
            modelBuilder.ApplyConfiguration(new TAConfig());
        }
    }
}
