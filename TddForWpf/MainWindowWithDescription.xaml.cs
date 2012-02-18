
using System.Windows.Input;
using Ninject;

namespace TddForWpf
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainWindowWithDescription
    {
       
        public MainWindowWithDescription()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(App.Calculate, CalculateExecuted));

            var view = App.Kernel.Get<CalculatorViewModel>();

            DataContext = view;

            //// Инициализация формы.
            //InitializeComponent();

            //// Подписываем окно на обработку команды Calculate.
            //// Подключаем метод обработки команды CalculateExecuted.
            //// Подключаем метод обработки возможности выполнения команды CalculateCanExecute.            
            //CommandBindings.Add(new CommandBinding(Calculate, CalculateExecuted));

            //// Создаем экземпляр модели калькулятора.
            //var view  = Kernel.Get<CalculatorViewModel>();

            //// Создаем экземпляр калькулятора и инжектируем в модель.
            //view.Calculator = Kernel.Get<ICalculator>();

            //// Устанавливаем модель контекстом главного окна.
            //DataContext = view;

        }

        /// <summary>
        /// Этот метод логики не содержит. Только для демонстрации.
        /// Если e.CanExecute установить в false, исходя из условий
        /// (пользователь еще не ввел данные, выполняется фоновая операция и т.д.)
        /// то все элементы (кнопки, элементы меню т.д.) вызывающие команду Calculate, будут заблокированы.
        /// В этом методе, логика должна быть не ресурсоемкой, так как вызывается этот метод при каждом
        /// изменении интерфейса (открытие меню, отображение формы и.д.)
        /// </summary> 
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        /// <summary>
        /// Обработка команды Calculate.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Модель калькулятора храниться в свойстве главного окна DataContext.
        /// Можно создать типизированное свойство DataContext View, тогда можно избавиться от приведения типа,
        /// тут дело личного предпочтения. Как по мне, то хранить модель в контексте формы логичнее.
        /// </remarks>
        private void CalculateExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ((CalculatorViewModel) DataContext).Calculate();
        }

    }
}