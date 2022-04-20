using System;

namespace TesteAudaz.Models
{
	public class Fare : IModel
	{
		public Guid Id { get; set; }
		public Guid OperatorId { get; set; }
		public int Status { get; set; }
		public DateTime Date { get; set; }
		public decimal Value { get; set; }
	}
}