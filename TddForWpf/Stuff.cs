using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace TddForWpf
{
    public interface ICalculator
    {
        int Add(string numbers);
    }

    public class CalculatorViewModelTests
    {
        private string numbers = "numbers";
        private int result = 123;
        private ICalculator calculator;
        private CalculatorViewModel viewModel;

        public CalculatorViewModelTests()
        {
            // arrange
            calculator = GetCalculator();
            viewModel = new CalculatorViewModel(calculator) {Numbers = numbers};

        }

        [Fact]
        public void should_update_result()
        {
            // act
            Act();

            // assert 
            viewModel.Result.Should().Be(result.ToString());
        }

        private void Act()
        {
            viewModel.Calculate.Execute(null);
        }

        [Fact]
        public void should_implement_NPC()
        {
            // assert
            viewModel.Should().BeAssignableTo<INotifyPropertyChanged>();
        }

        [Fact]
        public void should_raise_property_changed()
        {
            // arrange
            string propertyName = null;
            viewModel.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

            // act
            Act();

            // assert
            propertyName.Should().Be("Result");
        }

        private ICalculator GetCalculator()
        {
            var calculator = Substitute.For<ICalculator>();
            calculator.Add(numbers).Returns(result);
            return calculator;
        }
    }

    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private readonly ICalculator calculator;

        public CalculatorViewModel(ICalculator calculator)
        {
            this.calculator = calculator;
            Calculate = new SimpleCommand(() => InternalCalculate());
        }

        private string result;
        public string Result
        {
            get { return result; }
            private set
            {
                result = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Result"));
                }
            }
        }

        public string Numbers { get; set; }

        public ICommand Calculate { get; private set; }

        private void InternalCalculate()
        {
            Result = calculator.Add(Numbers).ToString(CultureInfo.InvariantCulture);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class SimpleCommand : ICommand
    {
        private readonly Action action;

        public SimpleCommand(Action action)
        {
            this.action = action;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
