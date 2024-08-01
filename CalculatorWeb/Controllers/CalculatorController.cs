using CalculatorApi;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWeb.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("add")]
        public ActionResult<int> Add(int start, int amount)
        {
            return _calculator.Add(start, amount);
        }

        [HttpGet("subtract")]
        public ActionResult<int> Subtract(int start, int amount)
        {
            return _calculator.Subtract(start, amount);
        }

        [HttpGet("multiply")]
        public ActionResult<int> Multiply(int start, int by)
        {
            return _calculator.Multiply(start, by);
        }

        [HttpGet("divide")]
        public ActionResult<int> Divide(int start, int by)
        {
            try
            {
                return _calculator.Divide(start, by);
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
