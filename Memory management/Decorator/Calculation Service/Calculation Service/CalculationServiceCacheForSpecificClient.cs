namespace Epam.NetMentoring.CalculationService
{
    public class CalculationServiceCacheForSpecificClient : CalculationServiceCache
    {
        private const int ClientIncrement = 10;

        public CalculationServiceCacheForSpecificClient(ICalculationService calculationService) : base(calculationService)
        {
        }

        public override decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return base.Calculate(firstParameter, secondParameter) + ClientIncrement;
        }
    }
}