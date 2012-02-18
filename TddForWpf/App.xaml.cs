
using System.Windows;
using System.Windows.Input;
using Ninject;

namespace TddForWpf
{
    public partial class App
    {

        #region "Entry Point"

        // Комманда "Calculate" и "Kernel" являются глобальными для всего приложения, поэтому лучше вынести
        // в класс App, а инициализацию в статический конструктор класса App, это будет своего рода точкой входа.
        // Если команд много, то лучше вынести в отдельный статический класс например CalulatorCommands.

        /// <summary>
        /// Представляет команду "Вычислить".
        /// </summary>
        public static readonly RoutedCommand Calculate;

        /// <summary>
        /// Тут все понятно.
        /// </summary>
        public static readonly StandardKernel Kernel;

        /// <summary>
        /// "Entry Point"
        /// </summary>
        static App()
        {
            // Тут коментарии не нужны.
            Kernel = new StandardKernel();
            Kernel.Bind<ICalculator>().To<Calculator>();
            Kernel.Bind<CalculatorViewModel>().ToSelf();
            Calculate = new RoutedCommand();
        }

        #endregion

        public App()
        {
            Startup += AppStartup;
        }

        private void AppStartup(object sender, StartupEventArgs e)
        {                       
            //MainWindow = new MainWindow();
            //MainWindow = new MainWindowOnlyXaml();
            //MainWindow = new MainWindowWithDescription();
        }

    }
}
