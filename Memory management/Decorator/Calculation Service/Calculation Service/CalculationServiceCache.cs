using System;
using System.Collections.Concurrent;

namespace Epam.NetMentoring.CalculationService
{
	public class CalculationServiceCache : ICalculationService
	{
		private static readonly ConcurrentDictionary<(decimal leftOperand, decimal rightOperand), decimal> Cache =
			new ConcurrentDictionary<(decimal, decimal), decimal>();

		protected readonly ICalculationService CalculationService;

		public CalculationServiceCache(ICalculationService calculationService)
		{
			CalculationService = calculationService ?? throw new ArgumentNullException(nameof(calculationService));
		}
		
		public virtual decimal Calculate(decimal leftOperand, decimal rightOperand)
		{
			return Cache.GetOrAdd((leftOperand, rightOperand),
								  valueFactory => CalculationService.Calculate(leftOperand, rightOperand));
		}
	}
}