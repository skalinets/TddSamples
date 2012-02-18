
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using FluentAssertions;
using Xunit;

namespace TddForWpf
{
    /// <summary>
    /// Тесты разметки XAML.
    /// </summary>
    /// <summary>>
    /// Добавил пару тестов XAML разметки. А то получается в примере, тесты для бизнес логики, 
    /// которая к WPF почти никакого отношения не имеет.
    /// Насчет тестов не ручаюсь, я только учусь. 
    /// Но примеры показывают реальные проблемы в WPF приложениях. 
    /// Одна из них, это потеря контекста данных, неправильные выражения привязок.
    /// </summary>
    public class CalculatorXamlTests
    {

        private CalculatorViewModel view;
        private FrameworkElement window;

        public CalculatorXamlTests()
        {
            // arrange            
            window = GetMainWindow();
            view = (CalculatorViewModel) window.DataContext;
        }

        /// <summary>
        /// Проверка наличия элементов.
        /// </summary>
        [Fact]
        public void should_elements()
        {

            // arrange

            // act
            var result = new FrameworkElement []
                             {
                                 (TextBox) window.FindName("NumbersTextBox"),
                                 (TextBox) window.FindName("ResultTextBox"),
                                 (Button) window.FindName("CalculateButton")
                             };
            
            // assert
            result.Should().OnlyContain(o=> o != null);

        }

        /// <summary>
        /// Проверка команды кнопки.
        /// </summary>
        [Fact]
        public void should_calculate_button_has_valid_command()
        {

            // arrange
            var button = (Button) window.FindName("CalculateButton");

            // "Бах" теста.
             button.Command = System.Windows.Input.ApplicationCommands.Cut;

            // act
            var result = button.Command;

            // assert
            result.Should().NotBeNull();

        }

        /// <summary>
        /// Вызов команды. Проверка правильности обработки команды формой.
        /// </summary>
        [Fact]
        public void should_calculate_result()
        {

            // arrange
            var button = (Button) window.FindName("CalculateButton");
            var command = (RoutedCommand) button.Command;

            view.Numbers = "1,2,3";

            // "Бах1" теста. 
            // window.DataContext = null;

            // "Бах2" теста.
            // view.Numbers = "1,2";

            // "Бах3" теста. Вызываем другую команду, на которую форма не подписывалась.
            // command = new RoutedCommand();

            // act            
            command.Execute(null, window);

            // assert
            view.Result.Should().Be("6");

        }

        /// <summary>
        /// Проверка что контекст поля для ввода, установлен правильно.
        /// </summary>
        [Fact]
        public void should_numbers_text_box_valid_context()
        {

            // arrange            
            var textBox = (TextBox)window.FindName("NumbersTextBox");
            
            // "Бах1" теста.
            // window.DataContext = new CalculatorViewModel();

            // "Бах2" теста.
            //textBox.DataContext = new CalculatorViewModel();

            // act
            var result = textBox.DataContext;

            // assert
            result.Should().Be(view);

        }

        /// <summary>
        /// Проверка что контекст поля Numbers, установлен правильно.
        /// </summary>
        [Fact]
        public void should_result_text_box_valid_context()
        {

            // arrange            
            var textBox = (TextBox)window.FindName("ResultTextBox");

            // "Бах1" теста.
            // window.DataContext = new CalculatorViewModel();

            // "Бах2" теста.
            // textBox.DataContext = new CalculatorViewModel();

            // act
            var result = textBox.DataContext;

            // assert
            result.Should().Be(view);

        }
        
        /// <summary>
        /// Возвращаем FrameworkElement на случай, если ззахотим потестить другую форму,
        /// или вобще не форму (например панель, с такой же разметкой и бизнес логикой).
        /// </summary>
        /// <returns></returns>
        private FrameworkElement GetMainWindow()
        {
            return new MainWindow();
            //return new MainWindowOnlyXaml();
            //return new MainWindowWithDescription();
        }

    }
}