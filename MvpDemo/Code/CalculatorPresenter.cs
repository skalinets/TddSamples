using WebFormsMvp;

namespace MvpDemo
{
    public class CalculatorPresenter : Presenter<ICalculatorView>
    {
        private readonly ICalculator calculator;
        private readonly IPasswordValidator passwordValidator;

        public CalculatorPresenter(ICalculatorView view, ICalculator calculator, IPasswordValidator passwordValidator) : base(view)
        {
            this.calculator = calculator;
            this.passwordValidator = passwordValidator;
            view.Calculate += (sender, args) =>
                                  {
                                      CalculatorModel calculatorModel = view.Model;
                                      string result = calculator.Add(args.Numbers);
                                      calculatorModel.Result = result;
                                  };

            view.ValidatePassword += (sender, args) =>
                                         {
                                             var model = view.Model;
                                             model.PasswordValidationResult = passwordValidator.Validate(args.Password);
                                             model.Result = "I was set from another place!!! WTF";
                                         };
        }
    }
}