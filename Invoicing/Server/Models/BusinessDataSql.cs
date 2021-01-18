using Invoicing.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Invoicing.Server.Models
{
    public class BusinessDataSql : IBusinessData, IDisposable
    {
        private SqlConnection cnct;

        public BusinessDataSql(string connectionString)
        {
            cnct = new SqlConnection(connectionString);
        }

        public IEnumerable<Invoice> AllInvoices =>
            cnct.Query<Invoice>("SELECT * FROM Factures ORDER BY Created DESC");

        public decimal SalesRevenue => throw new NotImplementedException();

        public decimal Outstanding => throw new NotImplementedException();

        public void Add(Invoice newInvoice)
        {
            string sql = "INSERT INTO Factures(Reference, Date, Customer, Amount) VALUES(@Reference,@Created,@Customer,@Amount); SELECT CAST(SCOPE_IDENTITY() as int)";
            cnct.ExecuteScalar<int>(sql, newInvoice);
        }

        public void Dispose()
        {
            cnct.Dispose();
        }
    }
}
