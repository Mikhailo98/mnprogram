namespace Calculator.BinaryOperations
{
    public class Addition : BinaryOperation
    {
        public Addition(IOperation leftOperand, IOperation rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double Calculate()
        {
            return LeftOperand.Calculate() + RightOperand.Calculate();
        }
    }
}