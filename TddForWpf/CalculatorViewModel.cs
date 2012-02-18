
using System.ComponentModel;
using System.Globalization;

namespace TddForWpf
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        
        public CalculatorViewModel()
        {            
        }

        public CalculatorViewModel(ICalculator calculator)
        {
            this.Calculator = calculator;            
        }

        public ICalculator Calculator { get; set; }

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
            Result = Calculator.Add(Numbers).ToString(CultureInfo.InvariantCulture);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}