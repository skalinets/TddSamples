using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalUtilities.Utilities;

namespace Playground.Core
{
    public class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return "Product: {0} Price: {1}".FormatWith(this.Id, this.Price);
        }
    }
}
