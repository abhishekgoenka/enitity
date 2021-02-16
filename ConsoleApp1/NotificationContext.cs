using SmartPlan.Models.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ConsoleApp1
{
    class NotificationContext : DbContext
    {
        public NotificationContext(): base("NotificationContext")
        {

        }

        public DbSet<SpSmartplan> SpSmartplans { get; set; }
        public DbSet<SpNotificationtrigger> SpNotificationtriggers { get; set; }
        public DbSet<SpNotificationmessage> SpNotificationmessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // configures one-to-many relationship
                modelBuilder.Entity<SpNotificationtrigger>()
                    .HasRequired<SpSmartplan>(s => s.IdSmartplanNavigation)
                    .WithMany(g => g.SpNotificationtriggers)
                    .HasForeignKey<Guid>(s => s.IdSmartplan);

            modelBuilder.Entity<SpNotificationmessage>()
                .HasRequired<SpNotificationtrigger>(s => s.IdNotificationtriggerNavigation)
                .WithMany(g => g.SpNotificationmessages)
                .HasForeignKey<Guid>(s => s.IdNotificationtrigger);

        }
    }
}
