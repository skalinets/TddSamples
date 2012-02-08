using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public static class ControlsExtensions
    {
        public static T Get<T> (this IDictionary<string, object> controls, string controlId) where T : class
        {
            return (T) controls[controlId];
        }
    }

    public partial class Legacy : System.Web.UI.Page
    {
        private IDictionary<string, object> _pageControls;

        public void _Page_Load(object sender, EventArgs e, IDictionary<string, object> controls, bool postBack)
        {
            _pageControls = controls;

            if (!postBack)
            {
                PageLoad();
            }
            else
            {
                // store some data..
                PagePostBack();
            }

            var requestParam = HttpContext.Current.Request["q"];

            HttpContext.Current.Response.Write("Hi from Response");
            HttpContext.Current.Response.End();
        }

        private void PagePostBack()
        {
            _pageControls.Get<Label>("Label").Text = "Hi TDD class!";
        }

        private void PageLoad()
        {
            _pageControls.Get<Label>("Label").Text = "Hello world!";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IDictionary<string, object> controls = new Dictionary<string, object>
                                                       {
                                                           {"Label", Label}
                                                       };

            _Page_Load(sender, e, controls, Page.IsPostBack);
        }
    }
}