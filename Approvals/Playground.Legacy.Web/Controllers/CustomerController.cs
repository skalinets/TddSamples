using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Playground.Legacy.Web.Data;

namespace Playground.Legacy.Web.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Orders(string id)
        {
            var dataContext = new NorthwindDataContext();
            var orders = dataContext.Orders.Where(o => o.CustomerID == id);

            return View(orders.ToList());
        }

    }
}
