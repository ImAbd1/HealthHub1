using Microsoft.AspNetCore.Mvc;

namespace HealthHub1.Controllers {
    public class AccountController1 : Controller {
        public IActionResult Login() {
            return View();
        }
        public IActionResult Register() {
            return View();
        }
    }
}
