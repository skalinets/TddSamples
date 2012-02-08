using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ApprovalTests.Reporters;
using Playground.Legacy.Web.Data;

namespace Playground.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class LegacyWebTests
    {
        [Test]
        public void should_lock_orders_page()
        {
            // do
            var customers = GetAllCustomers();

            var output = new StringBuilder();
            foreach (var customer in customers)
            {
                var url = string.Format("http://localhost:62598/customer/orders/{0}", customer);
                output.Append(ApprovalTests.Asp.Approvals.GetUrlContents(url));
            }

            // verify
            ApprovalTests.Approvals.Approve(output);
        }

        private IList<string> GetAllCustomers()
        {
            var dataContext = new NorthwindDataContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
            return dataContext.Customers.Select(c => c.CustomerID).ToList();
        }
    }
}
