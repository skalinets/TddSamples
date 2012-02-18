
using System.Windows.Input;
using Ninject;

namespace TddForWpf
{
    public partial class MainWindow
    {

        public MainWindow()
        {     
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(App.Calculate, CalculateExecuted));

            var view = App.Kernel.Get<CalculatorViewModel>();

            DataContext = view;
        }

        private void CalculateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((CalculatorViewModel) DataContext).Calculate();            
        }

    }
}
