using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TripLog.Models
{
    public class TripConfig : IEntityTypeConfiguration<TripsLog>
    {
        public void Configure(EntityTypeBuilder<TripsLog> entity)
        {
            entity.HasOne(t => t.Destination)
                .WithMany(d => d.TripsLogs)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(t => t.Accommodation)
                .WithMany(a => a.TripsLogs)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
