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
            this.Сalculator = calculator;            
        }

        public ICalculator Сalculator { get; set; }

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
            Result = Сalculator.Add(Numbers).ToString(CultureInfo.InvariantCulture);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}