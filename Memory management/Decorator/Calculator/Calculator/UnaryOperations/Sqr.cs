using System;

namespace Calculator.UnaryOperations
{
    internal class Sqr : UnaryOperation
    {
        public Sqr(IOperation operand) : base(operand)
        {
        }

        public override double Calculate()
        {
            return Math.Pow(Operand.Calculate(), 2);
        }
    }
}