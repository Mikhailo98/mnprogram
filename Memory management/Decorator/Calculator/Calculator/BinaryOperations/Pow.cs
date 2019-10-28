using System;

namespace Calculator.BinaryOperations
{
    public class Pow : BinaryOperation
    {
        public Pow(IOperation leftOperand, IOperation rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double Calculate()
        {
            return Math.Pow(LeftOperand.Calculate(), RightOperand.Calculate());
        }
    }
}