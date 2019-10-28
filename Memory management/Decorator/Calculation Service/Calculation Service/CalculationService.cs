using System.Threading;

namespace Epam.NetMentoring.CalculationService
{
    public class CalculationService : ICalculationService
    {
        public decimal Calculate(decimal leftOperand, decimal rightOperand)
        {
            Thread.Sleep(1000);
            return leftOperand * leftOperand + 2 * leftOperand
                                                       * rightOperand * rightOperand * rightOperand;
        }
    }
}