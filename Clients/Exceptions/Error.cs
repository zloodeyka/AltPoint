namespace Clients.Exceptions
{
	public class Error : Exception
	{
		public int Status { get; set; }

		public string Code { get; set; }
	}
}
