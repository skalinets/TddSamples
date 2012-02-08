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
            Model.Input = TextBox1.Text;
            Calculate(this, EventArgs.Empty);
        }

        public event EventHandler Calculate;
    }
}