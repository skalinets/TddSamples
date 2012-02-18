using System;
using System.Collections.Generic;
using System.Web;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace MvpDemo
{
    public class CalculatorPresenterTests
    {
        private readonly string numbers = "1,2,3";
        private readonly string calculationResult = "9898jd";
        private readonly ICalculatorView calculatorView = Substitute.For<ICalculatorView>();
        private readonly ICalculator calculator = Substitute.For<ICalculator>();
        private readonly CalculatorModel calculatorModel;

        public CalculatorPresenterTests()
        {
            calculatorModel = new CalculatorModel();
        }

        [Fact]
        public void should_calculate_sum_and_update_result_when_event_is_raised()
        {
            // arrange
            calculator.Add(numbers).Returns(calculationResult);

            var presenter = new CalculatorPresenter(calculatorView, calculator);
            calculatorView.Model.Returns(calculatorModel);

            // act
            calculatorView.Calculate += Raise.EventWith(calculatorView, new CalculatorArgs{Numbers = numbers});

            // assert
            calculatorView.Model.Result.Should().Be(calculationResult);
        }
    }
}