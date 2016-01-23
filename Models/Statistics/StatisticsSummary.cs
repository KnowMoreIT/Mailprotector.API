namespace CloudPanel.Spam.Mailprotector.Models
{
    public class StatisticsSummary
    {
        public int spamcount { get; set; }

        public int viruscount { get; set; }

        public int policycount { get; set; }

        public int deliveredcount { get; set; }

        public int attackcount { get; set; }

        public int totalcount { get; set; }

        public float spampercentage { get; set; }

        public float viruspercentage { get; set; }

        public float policypercentage { get; set; }

        public float deliveredpercentage { get; set; }

        public float attackpercentage { get; set; }

        public float blockpercentage { get; set; }

        public int blockeddata { get; set; }

        public int blockedperday { get; set; }

        public float timebetweenspam { get; set; }

        public string timebetweenspamlabel { get; set; }
       
    }
}
