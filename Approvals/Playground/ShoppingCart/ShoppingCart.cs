using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalUtilities.Utilities;

namespace Playground.Core {
    public class ShoppingCart {
        IList<Product> productsList = new List<Product>();
        decimal totalPrice = 0;

        public void Add(Product product) {
            this.productsList.Add(product);
        }

        public void Confirm() {
            foreach (var product in this.productsList) {
                totalPrice += product.Price;
            }
        }

        public override string ToString() {
            return "Total products in cart: {0}\nProducts: {1}\nTotal price: {2}".FormatWith(this.productsList.Count, this.productsList.ToReadableString(), totalPrice);
        }
    }
}
