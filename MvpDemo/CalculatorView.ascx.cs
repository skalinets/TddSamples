using System;
using WebFormsMvp.Web;

namespace MvpDemo
{
    public partial class CalculatorView : MvpUserControl<CalculatorModel>, ICalculatorView
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calculate(this, new CalculatorArgs{Numbers = TextBox1.Text});
        }

        public event EventHandler<CalculatorArgs> Calculate;
        public event EventHandler<ValidatePasswordArgs> ValidatePassword;

        protected void Button2_Click(object sender, EventArgs e)
        {
            ValidatePassword(this, new ValidatePasswordArgs{Password = TextBox2.Text});
        }
    }
}