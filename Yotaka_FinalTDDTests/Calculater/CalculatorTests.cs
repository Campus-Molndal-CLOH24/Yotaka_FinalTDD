using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yotaka_FinalTDD.Calculater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Calculater.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        private Calculator calculator;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [DataTestMethod()]
        [DataRow(1.5f, 2.5f, 4.0f)]
        [DataRow(0, 0, 0)]
        [DataRow(-1.5f, -2.5f, -4.0f)]
        [DataRow(-1.5f, 2.5f, 1.0f)]

        public void Add_returnCorrectSum(float a, float b, float expected)
        {
            //act
            float result = calculator.Add(a, b);
            //assert
            Assert.AreEqual(expected, result, 0.0001f);
        }


        //throw exception when input is invalid
        [TestMethod()]
        public void Add_InvalidInput_ThrowsFormatException()
        {
            // Act & Assert
            Assert.ThrowsException<FormatException>(() =>
            {
                float parsedA = float.Parse("a"); // "a" is not a valid number
            });
        }

        [DataTestMethod()]
        [DataRow(1.0f, 2.2f, -1.2f)]
        [DataRow(0, 0, 0)]
        [DataRow(-1.5f, -2.5f, 1.0f)]
        [DataRow(-1.5f, 2.5f, -4.0f)]

        public void Subtract_returnCorrectSum(float a, float b, float expected)
        {
            //act
            float result = calculator.Subtract(a,b);
            //assert
            Assert.AreEqual(expected, result, 0.0001f);
        }


        [TestMethod()]
        public void Subtract_InvalidInput_ThrowsFormatException()
        {
            // Act & Assert
            Assert.ThrowsException<FormatException>(() =>
            {
                float parsedA = float.Parse("a"); // "a" is not a valid number
            });
        }

        [DataTestMethod()]
        [DataRow(1.0f, 2.0f, 2.0f)]
        [DataRow(0, 0, 0)]
        [DataRow(-1.5f, -2.5f, 3.75f)]
        [DataRow(-1.5f, 2.5f, -3.75f)]
        [DataRow(-4.0f, 2.5f, -10.0f)]
        public void Multiply_returnCorrectSum(float a, float b, float expected)
        {
            //act
            float result = calculator.Multiply(a, b);
            //assert
            Assert.AreEqual(expected, result, 0.0001f);
        }
        [TestMethod()]
        public void Multiply_InvalidInput_ThrowsFormatException()
        {
            // Act & Assert: Invalid numeric input
            Assert.ThrowsException<FormatException>(() =>
            {
                float parsedA = float.Parse("a"); // "a" is not a valid number
            });
        }

        [TestMethod()]
        [DataRow(1.0f, 2.0f, 0.5f)]
        [DataRow(0, 1, 0)]
        [DataRow(-1.5f, -2.5f, 0.6f)]
        [DataRow(-1.5f, 2.5f, -0.6f)]
        [DataRow(-4.0f, 2.5f, -1.6f)]

        public void Divide_returnCorrectSum(float a, float b, float expected)
        {
            //act
            float result = calculator.Divide(a, b);
            //assert
            Assert.AreEqual(expected, result, 0.0001f);
        }


        //divide by zero
        [TestMethod()]
        public void Divide_DivideByZero_ThrowException()
        {
            //act
            Assert.ThrowsException<DivideByZeroException>(() => calculator.Divide(1, 0));
        }


        //invalid input
        [TestMethod]
        public void Divide_InvalidInput_ThrowsFormatException()
        {
            // Act & Assert: Invalid numeric input
            Assert.ThrowsException<FormatException>(() =>
            {
                float parsedA = float.Parse("a"); // "a" is not a valid number
            });
        }


        // Null input
        [TestMethod()]
        public void Divide_NullInput_ThrowsArgumentNullException()
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                float parsedA = float.Parse(null); // null is not a valid. 
            });
        }




    }
}