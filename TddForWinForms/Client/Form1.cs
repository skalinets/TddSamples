using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Container = StructureMap.Container;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var container = new Container(c => c.For<ICalculator>().Use<Calculator>());
            var viewModel = container.GetInstance<ViewModel>();
            InitializeComponent();
            button1.Click += viewModel.Add;
            viewModelBindingSource.DataSource = new [] {viewModel};
        }

        private void viewModelBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }

    public class Calculator : ICalculator
    {
        public int Add(string numbers)
        {
            return numbers.Split(',').Sum(s => Int32.Parse(s));
        }
    }
}