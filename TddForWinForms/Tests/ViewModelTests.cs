using System;
using Client;
using FluentAssertions;
using NSubstitute;
using Xunit;
using FluentAssertions.EventMonitoring;

namespace Tests
{
    public class ViewModelTests
    {
        private ViewModel viewModel;
        private int result;

        [Fact]
        public void should_update_result()
        {
            // act
            Act();

            // assert
            viewModel.Result.Should().Be(result.ToString());
        }

        [Fact]
        public void should_raise_event()
        {
            // arrange
            viewModel.MonitorEvents();

            // act
            Act();

            // assert
            viewModel.ShouldRaise("ResultChanged")
                .WithSender(viewModel)
                .WithArgs<EventArgs>(e => e == EventArgs.Empty);
        }

        public ViewModelTests()
        {
            // arrange
            var calculator = Substitute.For<ICalculator>();
            viewModel = new ViewModel(calculator);
            string numbers = "dsfas";
            result = 999;
            calculator.Add(numbers).Returns(result);
            viewModel.Numbers = numbers;
        }

        private void Act()
        {
            viewModel.Add(null, EventArgs.Empty);
        }
    }
}