
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace TddForWpf
{
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
            viewModel.Calculate();
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
}