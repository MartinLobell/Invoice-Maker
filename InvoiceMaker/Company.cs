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
    class Company
    {
        string m_companyname { get; }
        string m_streetaddress { get; }
        string m_zipcode { get; }
        string m_city { get; }
        string m_country { get; }

        public Company(string companyname, string streetaddress, string zipcode, string city, string country)
        {
            m_companyname = companyname;
            m_streetaddress = streetaddress;
            m_zipcode = zipcode;
            m_city = city;
            m_country = country;
        }

        public override string ToString()
        {
            return m_companyname + ", " + m_streetaddress + ", " + m_zipcode + ", " + m_city + ", " + m_country;
        }
            
    }
}
