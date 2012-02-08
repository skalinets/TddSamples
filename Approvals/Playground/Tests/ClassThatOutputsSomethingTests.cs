using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ApprovalTests;
using Playground.Legacy;
using ApprovalTests.Reporters;

namespace Playground.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class ClassThatOutputsSomethingTests
    {
        [Test]
        public void should_be_able_to_test()
        {
            var some = new ClassThatOutputsSomething();
            var output = ApprovalUtilities.SimpleLogger.Logger.LogToStringBuilder();

            //some.MethodThatProduceSomeResults("param1", 1);

            var products = GetAllProducts();

            foreach (var product in products)
            {
                some.MethodThatProduceSomeResults(product.Name, product.Price);
            }

            Approvals.Approve(output);
        }

        private dynamic GetAllProducts()
        {
            return new List<dynamic>
            {
                new { Name = "xxx", Price = 100 },
                new { Name = "zzz", Price = 200 },
                new { Name = "qqq", Price = 300 },
                new { Name = "eee", Price = 400 },
            };
        }
    }
}
