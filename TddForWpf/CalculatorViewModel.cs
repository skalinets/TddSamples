
using System.ComponentModel;
using System.Globalization;

namespace TddForWpf
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        
        public CalculatorViewModel(ICalculator calculator)
        {
            this.calculator = calculator;            
        }

        private ICalculator calculator;

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

        private string _numbers;
        public string Numbers
        {
            get { return _numbers; }
            set { _numbers = value; }
        }


        public void Calculate()
        {
            Result = calculator.Add(Numbers).ToString(CultureInfo.InvariantCulture);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}