namespace Clients.Exceptions
{
	public class ValidationException
	{
		public string Field { get; set; }
		public string Rule { get; set; }
		public string Message { get; set; }	
	}
}
