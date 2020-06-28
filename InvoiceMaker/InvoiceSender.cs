// Assignment 6.
// Martin Lobell
// 2020-05-20

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceMaker
{
    class InvoiceSender : Company
    {
        string m_phonenumber { get; }
        string m_url { get; }

        public InvoiceSender(string companyname, string streetaddress, string zipcode, string city, string country, string phonenumber, string url)
        : base(companyname, streetaddress, zipcode, city, country)
        {
            m_phonenumber = phonenumber;
            m_url = url;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + m_phonenumber + ", " + m_url;
        }
    }
}
