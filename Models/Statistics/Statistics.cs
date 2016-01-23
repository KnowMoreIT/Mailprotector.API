using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class Statistics
    {
        public StatisticsSummary summary { get; set; }

        public StatisticsData data { get; set; }
    }
}
