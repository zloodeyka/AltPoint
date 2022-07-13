namespace Clients.Exceptions
{
	public class EntityNotFoundError : Error
	{
		public EntityNotFoundError()
		{
			Status = 404;
			Code = "ENTITY_NOT_FOUND";
		}
	}
}
