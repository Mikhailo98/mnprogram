using System;

namespace Calculator.BinaryOperations
{
    public class Division : BinaryOperation
    {
        public Division(IOperation leftOperand, IOperation rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double Calculate()
        {
            var rightOperandResult = RightOperand.Calculate();
            if (rightOperandResult.Equals(0))
                throw new DivideByZeroException();

            return LeftOperand.Calculate() / RightOperand.Calculate();
        }
    }
}