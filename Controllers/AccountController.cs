using HealthHub1.Models;
using HealthHub1.Services;
using HealthHub1.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub1.Controllers {
    public class AccountController : Controller {
        private readonly DoctorService _doctorService;
        private readonly NurseService _nurseService;

        public AccountController(DoctorService doctorService, NurseService nurseService) {
            _doctorService = doctorService;
            _nurseService = nurseService;
        }

        // Register action (GET and POST)
        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            if (!ModelState.IsValid) {
                return View(model);
            }

            if (model.Position == "Doctor") {
                var doctor = new Doctor {
                    Name = model.Name,
                    Specialization = model.Specialization,
                    Email = model.Email,
                    Password = model.Password
                };
                await _doctorService.AddDoctor(doctor);  // Async call
            } else if (model.Position == "Nurse") {
                var nurse = new Nurse {
                    Name = model.Name,
                    Specialization = model.Specialization,
                    Email = model.Email,
                    Password = model.Password,
                    ContactNumber = model.ContactNumber
                };
                await _nurseService.AddNurse(nurse);  // Async call
            }

            // Save the user's email and position in the session
            HttpContext.Session.SetString("UserId", model.Email);
            HttpContext.Session.SetString("Position", model.Position);

            return RedirectToAction("Login", "Account");
        }

        // Login action (GET and POST)
        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(LoginViewModel model) {
        //    if (!ModelState.IsValid) {
        //        return View(model);
        //    }

        //    // Retrieve user data from session or database (simple check for example)
        //    var userEmail = HttpContext.Session.GetString("UserId");
        //    var userPosition = HttpContext.Session.GetString("Position");

        //    if (userEmail == model.Email && userPosition == model.Position) {
        //        // Redirect to appropriate dashboard based on the user's position
        //        if (userPosition == "Doctor") {
        //            return RedirectToAction("DoctorDashboard", "Dashboard");
        //        } else if (userPosition == "Nurse") {
        //            return RedirectToAction("NurseDashboard", "Dashboard");
        //        }
        //    }

        //    // If login failed
        //    ModelState.AddModelError("", "Invalid login attempt.");
        //    return View(model);
        //}
        //}
    }
}
