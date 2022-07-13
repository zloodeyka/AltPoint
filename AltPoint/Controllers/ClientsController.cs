using AltPoint.Entities.Response;
using Microsoft.AspNetCore.Mvc;

namespace AltPoint.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ClientsController : ControllerBase
	{
		public ActionResult<PaginationResponseBody> GetList()
		{

		}
	}
}