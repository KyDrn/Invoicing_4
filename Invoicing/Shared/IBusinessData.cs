using System.Collections.Generic;
using System.Linq;

namespace Invoicing.Shared
{
    public interface IBusinessData
    {
        IEnumerable<Invoice> AllInvoices { get; }
        decimal SalesRevenue { get; }
        decimal Outstanding { get; }

        public void Add(Invoice newInvoice);
    }
}
