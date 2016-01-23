using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class Spam_Tolerance
    {
        public string entity_type { get; set; }

        public int enitty_id { get; set; }

        public int possible_spam_min_score { get; set; }

        public int possible_spam_max_score { get; set; }

        public string possible_spam_text_location { get; set; }

        public string possible_spam_text { get; set; }
    }
}
