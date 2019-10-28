namespace Calculator.BinaryOperations
{
    public class Multiplication : BinaryOperation
    {
        public Multiplication(IOperation leftOperand, IOperation rightOperand) : base(leftOperand, rightOperand)
        {
        }

        public override double Calculate()
        {
            return LeftOperand.Calculate() * RightOperand.Calculate();
        }
    }
}