using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clients.Enums;
using DataAccess.Entities;

namespace Clients.Entities
{
	public class JobData
	{
		public Guid Id { get; set; }
		public TypeWork? Type { get; set; }
		public DateTime? DateEmp { get; set; }
		public DateTime? DateDismissal { get; set; }
		public decimal? MonIncome { get; set; }
		public string Tin { get; set; }
		public string PhoneNumber { get; set; }
		public Guid? FactAddressId { get; set; }
		public Guid? JurAddressId { get; set; }
		public AddressData FactAddress { get; set; }
		public AddressData JurAddress { get; set; }
	}
}
