
namespace DataAccess.Entities
{
	public  class Child : ClientEntity
	{
		
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Patronymic { get; set; }
		public DateTime? Dob { get; set; }
	}
}
