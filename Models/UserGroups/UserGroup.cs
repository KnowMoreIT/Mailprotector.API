using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class UserGroup
    {
        public int domain_id { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public string created_at { get; set; }

        public int user_count { get; set; }

        public Services[] services { get; set; }
    }

    public class Services
    {
        public int id { get; set; }

        public string name { get; set; }

        public string code { get; set; }
    }
}
