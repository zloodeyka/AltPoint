using Clients.Enums;
using System;
using System.Collections.Generic;

namespace DataAccess.Entities
{
	public class Job : ClientEntity
	{
		public TypeWork? Type { get; set; }
		public DateTime? DateEmp { get; set; }
		public DateTime? DateDismissal { get; set; }
		public decimal? MonIncome { get; set; }
		public string Tin { get; set; }	
		public string PhoneNumber { get; set; }
		public Guid? FactAddressId { get; set; }
		public Guid? JurAddressId { get; set; }
		public virtual Address? FactAddress { get; set; }
		public virtual Address? JurAddress { get; set; }
	}
}
