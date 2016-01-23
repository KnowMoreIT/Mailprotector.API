using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class MessageSummaries
    {
        public InboundSummaries inbound_summaries { get; set; }

        public OutboundSummaries outbound_summaries { get; set; }
    }

    public class InboundSummaries
    {
        public UserSummary user_summary { get; set; }
    }

    public class OutboundSummaries
    {
        public UserSummary user_summary { get; set; }
    }

    public class UserSummary
    {
        public int user_id { get; set; }

        public string username { get; set; }

        public int spam { get; set; }

        public int virus { get; set; }

        public int policy { get; set; }

        public int delivered { get; set; }

        public int total { get; set; }
    }
}
