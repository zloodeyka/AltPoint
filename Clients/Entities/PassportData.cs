using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clients.Entities
{
	public class PassportData
	{
		public Guid Id { get; set; }
		public string Series { get; set; }
		public string Number { get; set; }
		public string Giver { get; set; }
		public DateTime DateIssues { get; set; }
	}
}
