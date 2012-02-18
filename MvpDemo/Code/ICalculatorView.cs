using System;
using NSubstitute;
using WebFormsMvp;

namespace MvpDemo
{
    public interface ICalculatorView : IView<CalculatorModel>
    {
        event EventHandler<CalculatorArgs> Calculate;
        event EventHandler<ValidatePasswordArgs> ValidatePassword;
    }
}