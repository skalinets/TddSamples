using WebFormsMvp;

namespace MvpDemo
{
    public class CalculatorPresenter : Presenter<ICalculatorView>
    {
        private readonly ICalculator calculator;

        public CalculatorPresenter(ICalculatorView view, ICalculator calculator) : base(view)
        {
            this.calculator = calculator;
            view.Calculate += (sender, args) => {
                                                    var calculatorModel = view.Model;
                                                    calculatorModel.Result = calculator.Add(args.Numbers);
            };
        }
    }
}