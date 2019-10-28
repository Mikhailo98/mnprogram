using System;

namespace Calculator.UnaryOperations
{
    public abstract class UnaryOperation : IOperation
    {
        protected readonly IOperation Operand;

        protected UnaryOperation(IOperation operand)
        {
            Operand = operand ?? throw new ArgumentNullException(nameof(operand));
        }

        public abstract double Calculate();
    }
}