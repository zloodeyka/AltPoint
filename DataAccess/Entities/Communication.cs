using Clients.Enums;


namespace DataAccess.Entities
{
	public class Communication : ClientEntity
	{
		public TypeCommunication Type { get; set; }
		public string Value { get; set; }
	}
}
