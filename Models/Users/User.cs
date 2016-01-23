using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class User
    {
        public int id { get; set; }

        /// <summary>
        /// This is the name of the user, which corresponds to the username portion of an email address (jdoe@example.org would be jdoe).
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// This determines the type of user to add. The accepted options are “user”, “alias” and “mailing_list”. This value defaults to “user” unless otherwise specified.
        /// </summary>
        public string user_type { get; set; }

        /// <summary>
        /// This is the ID of the user to alias this new user to. This only applies to and is required for alias users.
        /// </summary>
        public int parent_id { get; set; }

        public int domain_id { get; set; }

        public int user_group_id { get; set; }

        /// <summary>
        /// First name for the user. (Optional)
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// Last name for the user. (Optional)
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// When the user was created
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        /// This is the password for this user’s email account. This is optional for non-hosted email users.
        /// </summary>
        public string password { get; set; }
    }
}
