
namespace Clients.Exceptions{
	public class ServerError : Error
	{
		public ServerError()
		{
			Status = 500;
			Code = "INTERNAL_SERVER_ERROR";
		}
	}
}
