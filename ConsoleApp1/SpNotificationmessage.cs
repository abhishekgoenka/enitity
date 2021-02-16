using System;
using System.Collections.Generic;

namespace SmartPlan.Models.Models
{
    public partial class SpNotificationmessage
    {
        public Guid Id { get; set; }
        public Guid IdNotificationtrigger { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDatetime { get; set; }

        public virtual SpNotificationtrigger IdNotificationtriggerNavigation { get; set; }
    }
}
