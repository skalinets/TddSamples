using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ApprovalTests;
using Playground.Core;
using ApprovalTests.Reporters;

namespace Playground.Tests
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class ShoppingCartTests
    {

        [Test]
        public void should_calculate_the_total_price_for_shopping_cart()
        {
            // do
            var shoppingCart = new ShoppingCart();
            shoppingCart.Add(new Product { Id = "iPad", Price = 500 });
            shoppingCart.Add(new Product { Id = "Mouse", Price = 20 });
            shoppingCart.Confirm();

            // verify
            Approvals.Approve(shoppingCart);
        }

    }
}
