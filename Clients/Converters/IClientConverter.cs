using System.Linq.Expressions;
using Clients.Entities;
using DataAccess.Entities;

namespace Clients.Converters
{
	public interface IClientConverter
	{
		public Expression<Func<Client, ClientData>> Convert();

		public Client Convert(ClientData data);
	}
}
