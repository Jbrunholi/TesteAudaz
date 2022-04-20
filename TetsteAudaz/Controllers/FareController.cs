using System;
using System.Linq;
using TesteAudaz.Models;
using TesteAudaz.Services;

namespace TesteAudaz.Controllers
{
	public class FareController
	{
		private readonly OperatorService operatorService;
		private readonly FareService fareService;

		public FareController()
		{
			operatorService = new OperatorService();
			fareService = new FareService();

			operatorService.Create(new Operator(Guid.NewGuid(), "OP01"));
			operatorService.Create(new Operator(Guid.NewGuid(), "OP02"));
			operatorService.Create(new Operator(Guid.NewGuid(), "OP03"));
			operatorService.Create(new Operator(Guid.NewGuid(), "OP04"));
			operatorService.Create(new Operator(Guid.NewGuid(), "OP05"));
		}

		public string CreateFare(Fare fare, string operatorCode)
		{
			var selectedOperator = operatorService.GetOperatorByCode(operatorCode);

			if (selectedOperator == null)
				return $"Não existe nenhuma entidade com o codigo '{operatorCode}'.";

			fare.OperatorId = selectedOperator.Id;

			var fareExistent = fareService.GetFares().FirstOrDefault(x => x.OperatorId == fare.OperatorId && x.Date > DateTime.Now.AddMonths(-6) && x.Value == fare.Value && x.Status == 1);

			if (fareExistent != null)
				return "A operadora informada está ativa e com esse valor, dentro de 6 meses.";

			fareService.Create(fare);

			return "sucess";
		}
	}
}