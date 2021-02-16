using Newtonsoft.Json;
using SmartPlan.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {

            //AddRecords();

            NotificationContext db = new NotificationContext();

            //var filter = db.SpNotificationtriggers.Select(e => new
            //{
            //    trigger_id = e.Id,
            //    bit_depth = e.BitDepth,
            //    hole_depth = e.HoleDepth
            //});

            var filter = from msg in db.SpNotificationmessages
                         join trigger in db.SpNotificationtriggers on msg.IdNotificationtrigger equals trigger.Id
                         join plan in db.SpSmartplans on trigger.IdSmartplan equals plan.Id
                         where plan.JobId == "T2021" && (trigger.BitDepth != null || trigger.HoleDepth != null)
                         select new

                         {
                             plan = plan.Name,
                             trigger_id = trigger.Id,
                             bit_depth = trigger.BitDepth,
                             hole_depth = trigger.HoleDepth
                         };


        var json = JsonConvert.SerializeObject(filter, Formatting.Indented);

            Console.WriteLine("Result {0}", json);

            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    

        private static void AddRecords()
        {
            NotificationContext db = new NotificationContext();
            SpSmartplan spSmartplan = new SpSmartplan
            {
                Id = Guid.NewGuid(),

                JobId = "T2021",
                Uwi = String.Empty,
                WellName = String.Empty,
                Name = "Job 1",
                Description = String.Empty,
                SpNotificationtriggers = new List<SpNotificationtrigger>
                {
                    new SpNotificationtrigger
                    {
                        Id = Guid.NewGuid(),
                        BitDepth = 2,
                        HoleDepth = 4,
                        SpNotificationmessages = new List<SpNotificationmessage>
                        {
                            new SpNotificationmessage
                            {
                                Id = Guid.NewGuid(),
                                Message = "Message 1",
                                MessageType = "Phone Message"
                            }
                        }
                    },
                    new SpNotificationtrigger
                    {
                        Id = Guid.NewGuid(),
                        BitDepth = null,
                        HoleDepth = null,
                        SpNotificationmessages = new List<SpNotificationmessage>
                        {
                            new SpNotificationmessage
                            {
                                Id = Guid.NewGuid(),
                                Message = "Message 2",
                                MessageType = "Phone Message"
                            }
                        }
                    }
                }
            };
            db.SpSmartplans.Add(spSmartplan);

            // Second record
            spSmartplan = new SpSmartplan
            {
                Id = Guid.NewGuid(),
                JobId = "Some Job ID",
                Uwi = String.Empty,
                WellName = String.Empty,
                Name = "Job 2",
                Description = String.Empty,
                SpNotificationtriggers = new List<SpNotificationtrigger>
                {
                    new SpNotificationtrigger
                    {
                        Id = Guid.NewGuid(),
                        BitDepth = 2,
                        HoleDepth = 4,
                        SpNotificationmessages = new List<SpNotificationmessage>
                        {
                            new SpNotificationmessage
                            {
                                Id = Guid.NewGuid(),
                                Message = "Message 3",
                                MessageType = "Phone Message"
                            }
                        }
                    }
                }
            };
            db.SpSmartplans.Add(spSmartplan);

            db.SaveChanges();


        }
    }
}
