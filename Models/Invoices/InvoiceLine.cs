using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector.Models
{
    public class InvoiceLine
    {
        public float cost { get; set; }

        public string description { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public float retail { get; set; }

        public InvoiceLine[] invoice_lines { get; set; }
    }
}
