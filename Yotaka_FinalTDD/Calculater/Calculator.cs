using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yotaka_FinalTDD.Calculater
{
    public class Calculator
    {
        public float Add(float a, float b)
        {
            return a+b;
        }
        public float Subtract(float a, float b) 
        {
            return a - b;
        }
        public float Multiply(float a, float b)
        {
            return a*b;
        }
        public float Divide(float a, float b)
        {
            switch (b)
            {
                case 0.0f:
                    throw new DivideByZeroException("Cannot divide by zero.");
                default:
                    return a / b;
            }
        }

    }
}
