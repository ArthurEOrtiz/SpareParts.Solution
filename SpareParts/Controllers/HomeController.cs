using Microsoft.AspNetCore.Mvc;

namespace SpareParts.Controllers
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