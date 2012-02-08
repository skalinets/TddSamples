using System;
using System.Linq;

namespace WebApplication2.Logic
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            var delimiters = new[] { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                delimiters = new[] { numbers.Substring(2, numbers.IndexOf('\n') - 2) };
                numbers = numbers.Substring(4);
            }

            var ints = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).Where(i => i < 1000);
            if (ints.Any(c => c < 0))
            {
                var negatives = ints.Where(i => i < 0);
                throw new NegativesAreNotAllowed(negatives);
            }

            return ints.Sum();
        }
    }
}