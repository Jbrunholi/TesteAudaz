using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteAudaz.Models
{
	public class Operator : IModel
	{
		public Operator(Guid id, string code)
		{
			Id = id;
			Code = code;
		}

		public Guid Id { get; set; }
		public string Code { get; set; }
	}
}