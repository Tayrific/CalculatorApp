using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApi;

namespace CalculatorTest
{
    [TestClass]
    public class SimpleCalculatorTests
    {
        private Mock<IDiagnostics> _mockDiagnostics;
        private ICalculator _calculator;

        [TestInitialize]
        public void SetUp()
        {
            _mockDiagnostics = new Mock<IDiagnostics>();
            _calculator = new Calculator(_mockDiagnostics.Object);
        }

        [TestMethod]
        public void Add_PositiveNumbers_ReturnsSum()
        {

            int start = 5;
            int amount = 3;


            var result = _calculator.Add(start, amount);

            Assert.AreEqual(8, result);
            _mockDiagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Add_NegativeNumbers_Test()
        {

            int start = -5;
            int amount = -3;

            var result = _calculator.Add(start, amount);

            Assert.AreEqual(-8, result);
            _mockDiagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Subtract_PositiveNumbers_Test()
        {
            int start = 10;
            int amount = 5;

            var result = _calculator.Subtract(start, amount);

            Assert.AreEqual(5, result);
            _mockDiagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Multiply_PositiveNumbers_Test()
        {
            int start = 4;
            int by = 3;

            var result = _calculator.Multiply(start, by);

            Assert.AreEqual(12, result);
            _mockDiagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Divide_PositiveNumbers_Test()
        {
            int start = 20;
            int by = 4;

            var result = _calculator.Divide(start, by);

            Assert.AreEqual(5, result);
            _mockDiagnostics.Verify(d => d.Log(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            int start = 10;
            int by = 0;

            var ex = Assert.ThrowsException<DivideByZeroException>(() => _calculator.Divide(start, by));
            Assert.AreEqual("Fatal : Cannot divide by zero!", ex.Message);
            _mockDiagnostics.Verify(d => d.Log("Divide by zero error"), Times.Once);
        }
    }
}
