using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class Account
    {
        public int id { get; set; }

        public string name { get; set; }

        public string account_status { get; set; }

        public DateTime created_at { get; set; }
    }
}
