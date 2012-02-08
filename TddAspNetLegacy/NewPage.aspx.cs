using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.Presenters;
using WebApplication2.Views;

namespace WebApplication2
{
    public partial class NewPage : System.Web.UI.Page, INewPageView
    {
        private NewPagePresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            presenter = new NewPagePresenter(this);
        }

        public void UpdateResultLabel(string result)
        {
            Result.Text = result;
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            presenter.Calculate(TextBox.Text);
        }
    }
}