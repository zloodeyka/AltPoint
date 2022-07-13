
namespace DataAccess.Entities
{
	public class Passport : ClientEntity
	{
		public string Series { get; set; }
		public string Number { get; set; }
		public string Giver { get; set; }
		public DateTime DateIssues { get; set; }

	}
}
