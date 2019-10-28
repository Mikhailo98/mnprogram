using Calculator.BinaryOperations;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            new Subtraction(
                    new Addition(
                        new Division(
                            new Multiplication(new Number(10), new Number(2)), new Number(4)), new Number(5)),
                    new Number(10))
                .Calculate();
        }
    }
}