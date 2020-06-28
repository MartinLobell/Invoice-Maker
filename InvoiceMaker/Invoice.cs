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
    class Invoice
    {
        List<Item> m_items;

        InvoiceSender m_sender;
        InvoiceReceiver m_receiver;
        string m_invoicenumber { get; }
        DateTime m_invoicedate { get; }
        DateTime m_duedate { get; }

        public Invoice(string invoicenumber, DateTime invoicedate, DateTime duedate,  InvoiceSender sender, InvoiceReceiver receiver, List<Item> items)
        {
            m_invoicenumber = invoicenumber;
            m_invoicedate = invoicedate;
            m_duedate = duedate;
        }
    }
}
