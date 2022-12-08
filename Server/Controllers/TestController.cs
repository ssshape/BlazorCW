using Microsoft.AspNetCore.Mvc;

namespace BlazorCW.Server.Controllers
{
	[Route("test/controller")]
	public class TestController : Controller
	{
		public IActionResult Index()
		{
			return Content("Hello World");
		}
	}
}
