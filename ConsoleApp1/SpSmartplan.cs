using System;
using System.Collections.Generic;

namespace SmartPlan.Models.Models
{
    public partial class SpSmartplan
    {
        public SpSmartplan()
        {
            SpNotificationtriggers = new HashSet<SpNotificationtrigger>();
        }

        public Guid Id { get; set; }
        public string JobId { get; set; }
        public string Uwi { get; set; }
        public string WellName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? PlannedStartDatetime { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsCompleted { get; set; }
        public DateTime? CreatedDatetime { get; set; }
        public DateTime? LastUpdatedDatetime { get; set; }

        public virtual ICollection<SpNotificationtrigger> SpNotificationtriggers { get; set; }
    }
}
