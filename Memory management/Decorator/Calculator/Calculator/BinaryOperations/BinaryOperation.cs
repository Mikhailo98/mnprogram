using System;

namespace Calculator.BinaryOperations
{
    public abstract class BinaryOperation : IOperation
    {
        protected readonly IOperation LeftOperand;
        protected readonly IOperation RightOperand;

        protected BinaryOperation(IOperation leftOperand, IOperation rightOperand)
        {
            LeftOperand = leftOperand ?? throw new ArgumentNullException(nameof(leftOperand));
            RightOperand = rightOperand ?? throw new ArgumentNullException(nameof(rightOperand));
        }

        public abstract double Calculate();
    }
}