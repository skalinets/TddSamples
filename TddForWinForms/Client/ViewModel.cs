using System;

namespace Client
{
    public class ViewModel
    {
        private readonly ICalculator calculator;

        public ViewModel()
        {
            Numbers = "3,4,5";
            Result = 23.ToString();
        }

        public ViewModel(ICalculator calculator) : this()
        {
            this.calculator = calculator;
        }

        public string Numbers { get; set; }

        public string Result { get;  set; }

        public event EventHandler ResultChanged;

        public void Add(object o, EventArgs empty)
        {
            Result = calculator.Add(Numbers).ToString();
            if (ResultChanged != null)
            {
                ResultChanged(this, EventArgs.Empty);
            }
        }
    }
}