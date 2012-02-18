using System;

namespace MvpDemo
{
    public class CalculatorArgs : EventArgs
    {
        public string Numbers { get; set; }
    }
}