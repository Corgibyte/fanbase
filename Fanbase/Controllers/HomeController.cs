using Microsoft.AspNetCore.Mvc;

namespace Fanbase.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}