namespace Clients.Exceptions
{
	public class ValidationError : Error
	{
		public List<ValidationException> Exceptions { get; set; }

		public ValidationError(List<ValidationException> exceptions)
		{
			Status = 422;
			Code = "VALIDATION_EXCEPTION";
			Exceptions = exceptions;
		}
	}
}
