using Clients.Entities;

namespace Clients.Managers
{
	public interface IClientsManager
	{
		public IQueryable<ClientData> GetList();

		public ClientData Get(Guid id);

		public Guid Create(ClientData data);

		public void Update(Guid clientId, ClientData data);

		public void Delete(Guid clientId);
	}
}
