using System;
using System.Collections.Generic;
using System.Linq;

namespace Invoicing.Shared
{
    public class BusinessTestData : IBusinessData
    {
        private Invoice[] testInvoices =
        {
            new Invoice(1, "B2345", "FOO", 2154.6m     , DateTime.Now),
            new Invoice(2, "B1345", "BAR", 12154.6m    , DateTime.Now),
            new Invoice(3, "R2145", "BAR", 254.6m      , DateTime.Now),
            new Invoice(4, "T2145", "BOO", 32154.52m   , DateTime.Now)
        };

        public BusinessTestData()
        {
            testInvoices[1].RegisterPayment(DateTime.Now, 12154.6m);
            testInvoices[3].RegisterPayment(DateTime.Now, 16077.26m);
            testInvoices[3].Expected = DateTime.Now;

            AllInvoices = testInvoices;
        }

        public decimal SalesRevenue => testInvoices.Sum(invoice => invoice.Amount);

        public decimal Outstanding => testInvoices.Sum(invoice => invoice.Amount - invoice.Paid);

        public IEnumerable<Invoice> AllInvoices { get; set; }

        public void Add(Invoice newInvoice)
        {
            AllInvoices = AllInvoices.Append(newInvoice);
        }
    }
}
