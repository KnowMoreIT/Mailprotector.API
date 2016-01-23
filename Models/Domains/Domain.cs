using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class Domain
    {
        public int account_id { get; set; }

        public string created_at { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public int? parent_id { get; set; }

        public string updated_at { get; set; }

        public int spam { get; set; }

        public int policy { get; set; }

        public int virus { get; set; }

        public int attacks { get; set; }

        public int delivered { get; set; }

        public int total { get; set; }

        public int all_valid_user_count { get; set; }

        public int active_user_count { get; set; }

        public int valid_user_count { get; set; }

        public int valid_mailing_list_count {get ;set; }

        public int valid_user_alias_count { get; set; }

        public List<DomainService> services { get; set; }

        public List<DomainAlias> domain_aliases { get; set; }
    }

    public class DomainService
    {
        public int id { get; set; }

        public string name { get; set; }

        public string code { get; set; }
    }

    public class DomainAlias
    {
        public int id { get; set; }

        public string name { get; set; }
    }
}
