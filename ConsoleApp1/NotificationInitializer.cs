using SmartPlan.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NotificationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<NotificationContext>
    {
        protected override void Seed(NotificationContext context)
        {
            var spSmartplans = new List<SpSmartplan>
            {
                new SpSmartplan
                {
                    Id = new Guid("e7a785ca-346e-4e6b-bbbb-1ec4df24d92c"),
                    JobId = "Job1",
                    Uwi = String.Empty,
                    WellName = String.Empty,
                    Name = "Job 1",
                    Description = String.Empty,
                }
            };
        }
    }
}
