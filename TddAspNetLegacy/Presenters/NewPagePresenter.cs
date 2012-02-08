using WebApplication2.Logic;
using WebApplication2.Views;

namespace WebApplication2.Presenters
{
    public class NewPagePresenter
    {
        private readonly INewPageView _view;

        public NewPagePresenter(INewPageView view)
        {
            _view = view;
        }

        public void Calculate(string numbers)
        {
            var calculator = new StringCalculator();

            int result = 0;
            try
            {
                result = calculator.Add(numbers);
            }
            catch (NegativesAreNotAllowed e)
            {
                _view.UpdateResultLabel(e.Message);
                return; 
            }

            _view.UpdateResultLabel(result > 0 ? result.ToString() : "");
        }
    }
}