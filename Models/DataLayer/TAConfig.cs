using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TripLog.Models
{
    public class TAConfig : IEntityTypeConfiguration<TripActivity>
    {
        public void Configure(EntityTypeBuilder<TripActivity> entity)
        {
            entity.HasKey(ta => new { ta.TripsLogId, ta.ActivityId });

            entity.HasOne(ta => ta.TripsLog)
                .WithMany(t => t.TripActivities)
                .HasForeignKey(ta => ta.TripsLogId);

            entity.HasOne(ta => ta.Activity)
                .WithMany(t => t.TripActivities)
                .HasForeignKey(ta => ta.ActivityId);
        }
    }
}
