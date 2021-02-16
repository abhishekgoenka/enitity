using System;
using System.Collections.Generic;

namespace SmartPlan.Models.Models
{
    public partial class SpNotificationtrigger
    {
        public SpNotificationtrigger()
        {
            SpNotificationmessages = new HashSet<SpNotificationmessage>();
        }

        public Guid Id { get; set; }
        public Guid IdSmartplan { get; set; }
        public Guid? IdPhaseActivity { get; set; }
        public Guid? IdPhase { get; set; }
        public decimal? BitDepth { get; set; }
        public decimal? HoleDepth { get; set; }
        public string ServiceName { get; set; }
        public bool? ActionTaken { get; set; }

        public virtual SpSmartplan IdSmartplanNavigation { get; set; }
        public virtual ICollection<SpNotificationmessage> SpNotificationmessages { get; set; }
    }
}
