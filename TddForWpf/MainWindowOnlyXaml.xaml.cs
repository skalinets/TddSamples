
using System.Windows.Input;

namespace TddForWpf
{
    /// <summary>
    /// Не для тестирования! Только для демонстрации работы с ресурсами.
    /// </summary>
    public partial class MainWindowOnlyXaml
    {

        public MainWindowOnlyXaml()
        {
            InitializeComponent();
        }

        private void CalculateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((CalculatorViewModel) DataContext).Calculate();
        }

    }
}
