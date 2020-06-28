// Assignment 6.
// Martin Lobell
// 2020-05-20

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    class InvoiceReceiver : Company
    {
        string m_name { get; }

        public InvoiceReceiver(string companyname, string streetaddress, string zipcode, string city, string country, string name)
        : base(companyname, streetaddress, zipcode, city, country)
        {
            m_name = name;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + m_name;
        }
    }
}
