using CalculatorApi;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            return Ok(_calculator.Add(a, b));
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b)
        {
            return Ok(_calculator.Subtract(a, b));
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b)
        {
            return Ok(_calculator.Multiply(a, b));
        }

        [HttpGet("divide")]
        public IActionResult Divide(int a, int b)
        {
            try
            {
                return Ok(_calculator.Divide(a, b));
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
