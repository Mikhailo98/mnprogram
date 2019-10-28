namespace Epam.NetMentoring.CalculationService
{
    public interface ICalculationService
    {
        decimal Calculate(decimal leftOperand, decimal rightOperand);
    }
}