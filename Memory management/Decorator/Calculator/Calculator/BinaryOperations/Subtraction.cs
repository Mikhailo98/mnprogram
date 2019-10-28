namespace Calculator.BinaryOperations
{
    internal class Subtraction : BinaryOperation
    {
        public Subtraction(IOperation leftOperand, IOperation rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double Calculate()
        {
            return LeftOperand.Calculate() - RightOperand.Calculate();
        }
    }
}