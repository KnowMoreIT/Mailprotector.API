using System;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class StatisticsDataInbound
    {
        public bool hasdata { get; set; }

        public DateTime[] days { get; set; }

        public string[] daysformatted { get; set; }

        public int[] spam { get; set; }

        public int[] viruses { get; set; }

        public int[] policy { get; set; }

        public int[] attacks { get; set; }

        public int[] delivered { get; set; }
    }
}
