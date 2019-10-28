namespace Calculator
{
    public class Number : IOperation
    {
        private readonly double _value;

        public Number(double value)
        {
            _value = value;
        }

        public double Calculate()
        {
            return _value;
        }
    }
}