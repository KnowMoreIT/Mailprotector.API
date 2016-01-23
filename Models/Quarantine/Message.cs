namespace CloudPanel.Spam.Mailprotector.Models
{
    public class Message
    {
        public int id { get; set; }

        public string sender { get; set; }

        public string from { get; set; }

        public string to { get; set; }

        public string subject { get; set; }

        public string date { get; set; }

        public string address { get; set; }
    }
}
