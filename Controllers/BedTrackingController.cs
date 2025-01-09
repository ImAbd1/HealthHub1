using Microsoft.AspNetCore.Mvc;

namespace HealthHub1.Controllers {
    public class BedTrackingController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
