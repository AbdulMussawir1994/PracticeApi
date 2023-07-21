using Microsoft.AspNetCore.Mvc;

namespace SingleIR.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
