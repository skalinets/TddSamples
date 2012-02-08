using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentAssertions;
using NSubstitute;
using WebFormsMvp;
using Xunit;

namespace MvpDemo
{
    public class CalculatorPresenterTests
    {
        [Fact]
        public void should_calculate_sum_and_update_result_when_event_is_raised()
        {
            // arrange
            var view = Substitute.For<ICalculatorView>();
            var calculator = Substitute.For<ICalculator>();
            string numbers = "1,2,3";
            string result = "9898jd";
            var presenter = new CalculatorPresenter(view);
            calculator.Add(numbers).Returns(result);
            var calculatorModel = new CalculatorModel();
            view.Model.Returns(calculatorModel);
            calculatorModel.Input = numbers;
            view.Model.Input.Should().Be(numbers);

            // act
            view.Calculate += Raise.EventWith(view, EventArgs.Empty);

            // assert
            view.Model.Result.Should().Be(numbers);
        }
    }

    public interface ICalculator
    {
        string Add(string numbers);
    }

    public class CalculateEventArgs : EventArgs
    {
        public string Numbers { get; set; }
    }

    public interface ICalculatorView : IView<CalculatorModel>
    {
        event EventHandler Calculate;
    }

    public class CalculatorModel
    {
        public string Result { get; set; }
        public string Input { get; set; }
    }

    public class CalculatorPresenter : Presenter<ICalculatorView>
    {
        public CalculatorPresenter(ICalculatorView view) : base(view) 
        {
            view.Calculate += (sender, args) => {
                                                    var calculatorModel = view.Model;
                                                    calculatorModel.Result = calculatorModel.Input;
                                                    Console.Out.WriteLine("view.Model.Input = {0}", calculatorModel.Input);
                                                    Console.Out.WriteLine("view.Model.Result = {0}", calculatorModel.Result);
            };
        }
    }
}