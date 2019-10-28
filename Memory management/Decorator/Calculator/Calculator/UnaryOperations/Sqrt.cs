using System;

namespace Calculator.UnaryOperations
{
    public class Sqrt : UnaryOperation
    {
        public Sqrt(IOperation operand) : base(operand)
        {
        }

        public override double Calculate()
        {
            var operandResult = Operand.Calculate();
            if (operandResult < 0)
                throw new ArgumentOutOfRangeException();

            return Math.Sqrt(operandResult);
        }
    }
}