using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApi
{
    public class Calculator : ICalculator
    {
        private readonly IDiagnostics _diagnostics;

        public Calculator() { }
        public Calculator(IDiagnostics diagnostics)
        {
            _diagnostics = diagnostics ?? throw new ArgumentNullException(nameof(diagnostics));
        }
        public int Add(int start, int amount)
        {
            int sum = start + amount;
            _diagnostics.Log($"Successfully Added: {start} + {amount} = {sum}");
            return sum;
        }

        public int Subtract(int start, int amount)
        {
            int difference = start - amount;
            _diagnostics.Log($"Successfully Subtracted: {start} - {amount} = {difference}");
            return difference;
        }

        public int Multiply(int start, int by)
        {
            int product = start * by;
            _diagnostics.Log($"Successfully Multiplied: {start} * {by} = {product}");
            return product;
        }

        public int Divide(int start, int by)
        {
            if (by == 0)
            {
                string err = "Fatal : Cannot divide by zero!";
                _diagnostics.Log("Divide by zero error");
                throw new DivideByZeroException(err);
            }
            else
            {
                int quotient = start / by;
                _diagnostics.Log($"Successfully Divided: {start} / {by} = {quotient}");
                return quotient;
            }
        }
    }
}
