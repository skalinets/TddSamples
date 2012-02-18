using System;
using WebFormsMvp;

namespace MvpDemo
{
    public interface ICalculatorView : IView<CalculatorModel>
    {
        event EventHandler<CalculatorArgs> Calculate;
    }
}