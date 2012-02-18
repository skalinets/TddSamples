using System;
using System.Globalization;
using System.Linq;

namespace MvpDemo
{
    class Calculator : ICalculator
    {
        public string Add(string numbers)
        {
            return numbers.Split(',').Sum(i => Int32.Parse(i)).ToString(CultureInfo.InvariantCulture);
        }
    }
}