using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ninject;
using NSubstitute;

namespace TddForWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CalculatorViewModel calculatorViewModel;
        private StandardKernel kernel;

        public MainWindow()
        {
            InitializeComponent();
            kernel = new StandardKernel();
            kernel.Bind<ICalculator>().To<Calculator>();
            kernel.Bind<CalculatorViewModel>().ToSelf();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            CollectionViewSource viewSource = ((CollectionViewSource)(this.FindResource("calculatorViewModelViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // calculatorViewModelViewSource.Source = [generic data source]
            calculatorViewModel = kernel.Get<CalculatorViewModel>();
            viewSource.Source = new[] {calculatorViewModel};
        }
    }

    internal class Calculator : ICalculator
    {
        public int Add(string numbers)
        {
            return numbers.Split(',').Sum(c => Int32.Parse(c));
        }
    }
}
