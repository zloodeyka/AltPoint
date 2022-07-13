
namespace DataAccess.Entities
{
	public class ClientEntity : Identity
	{
		public Guid ClientId { get; set; }
		public virtual Client Client { get; set; }
	}
}
