namespace AltPoint.Entities.Response
{
	public class PaginationResponseBody<T>
	{
		public int Limit {get; set;}
		public int Page { get; set;}
		public int Total { get; set;}

		public T[]? Data { get; set;}
	}
}
