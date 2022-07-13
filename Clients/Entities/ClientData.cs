using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clients.Enums;
using DataAccess.Entities;

namespace Clients.Entities
{
	public class ClientData
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public string Dob { get; set; }
		public int? CurWorkExp { get; set; }

		public TypeEducation? TypeEducation { get; set; }

		public decimal? MonIncome { get; set; }
		public decimal? MonExpenses { get; set; }

		public DateTime CreatedAt { get; set; }

		public DateTime UpdatedAt { get; set; }

		public Guid? SpouseId { get; set; }

		public List<ChildData> Children { get; set; }

		public List<Guid> DocumentIds { get; set; }

		public List<CommunicationData> Communications { get; set; }

		public List<JobData> Jobs { get; set; }

		public PassportData? Passport { get; set; }

		public AddressData? LivingAddress { get; set; }

		public AddressData? RegAddress { get; set; }

		public ClientData? Spouse { get; set; }
	}
}
