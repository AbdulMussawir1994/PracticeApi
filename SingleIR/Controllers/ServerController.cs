using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SingleIR.Hubs;
using SingleIR.Models;

namespace SingleIR.Controllers
{
    public class ServerController : Controller
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public ServerController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.NumberofClient = ConnectedUser.UserId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Notification model)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMsg", model.Message);
            return View();
        }
    }
}
