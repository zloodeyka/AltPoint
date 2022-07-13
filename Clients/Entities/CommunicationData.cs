using Clients.Enums;

namespace Clients.Entities
{
	public class CommunicationData
	{
		public Guid Id { get; set; }
		public TypeCommunication Type { get; set; }
		public string Value { get; set; }
	}
}
