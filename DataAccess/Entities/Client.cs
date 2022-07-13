using Clients.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class Client : Identity
	{
		public string Name { get; set; }
		public string Surname { get; set; }	
		public string Patronymic { get; set; }	
		public DateTime? Dob { get; set; }
		public int? CurWorkExp { get; set; }

		public TypeEducation? TypeEducation { get; set; }

		public decimal? MonIncome { get; set; }
		public decimal? MonExpenses { get; set; }

		public Guid? LivingAddressId { get; set; }

		public Guid? RegAddressId { get; set; }

		public Guid? SpouseId { get; set; }
		public Client? Spouse { get; set; }

		public virtual List<Child>? Children { get; set; }
		public virtual List<Document>? Documents { get; set; }
		public virtual List<Communication>? Communications { get; set; }

		public virtual List<Job>? Jobs { get; set; }	
		public virtual Passport? Passport { get; set; }
		public virtual Address? LivingAddress { get; set; }

		public virtual Address? RegAddress { get; set; }


	}
}
