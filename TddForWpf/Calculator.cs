using System;
using System.Linq;

namespace TddForWpf
{
    internal class Calculator : ICalculator
    {
        public int Add(string numbers)
        {
            return numbers.Split(',').Sum(c => Int32.Parse(c));
        }
    }
}