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
    class Item
    {
        public string m_description { get; set; }
        public int m_quantity { get; set; }
        public double m_unitprice { get; set; }
        public int m_tax { get; set; }

        public int m_number { get; set; }

        public double TotalTax()
        { 
            return m_quantity * m_unitprice * m_tax / 100;
        }

        public double TotalPrice()
        {
            return m_quantity * m_unitprice + m_quantity * m_unitprice * m_tax / 100;
        }

        public Item(string description, int quantity, double unitprice, int tax)
        {
            m_description = description;
            m_quantity = quantity;
            m_unitprice = unitprice;
            m_tax = tax;
        }

        public Item()
        {
        }

        public override string ToString()
        {
            return $"{m_number} \t {m_description} \t {m_quantity} \t\t {m_unitprice} \t\t {m_tax} \t {m_quantity * m_unitprice * m_tax / 100} \t\t {m_quantity * m_unitprice + m_quantity * m_unitprice * m_tax / 100}";
        }
    }
}
