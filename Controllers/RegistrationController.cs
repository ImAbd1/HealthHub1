using HealthHub1.Models;
using HealthHub1.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HealthHub1.Controllers {
    public class RegistrationController : Controller {
        private readonly PatientService _PatientService;
        private readonly BedService _bedService;

        public RegistrationController(PatientService patientService, BedService bedService) {
            _PatientService = patientService;
            _bedService = bedService;
        }

        public async Task<IActionResult> Index() {
            var availableBeds = await _bedService.GetAvailableBeds();

            // Create a list of SelectListItem with BedId as the value and formatted Bed string as the text
            ViewBag.BedOptions = availableBeds.Select(b => new SelectListItem {
                Value = b.BedId.ToString(), // Use BedId as the value
                Text = $"{b.Category}-{b.BedNumber}" // Use formatted string for display
            }).ToList();

            return View();
        }


        // POST method to handle form submission
        [HttpPost]
        public async Task<IActionResult> Index(Patient patient) {
            if (ModelState.IsValid) {
                _PatientService.AddPatient(patient);
                if (patient.BedId.HasValue) {
                    await _bedService.MarkUnavailable(patient.BedId.Value);
                }
                return RedirectToAction("Index");
            }

            await PopulateBedOptions();
            return View(patient);
        }

        // Helper method to populate ViewBag.BedOptions
        private async Task PopulateBedOptions() {
            var availableBeds = await _bedService.GetAvailableBeds();
            var bedOptions = availableBeds.Select(b => $"{b.Category}-{b.BedNumber}").ToList();
            ViewBag.BedOptions = bedOptions;
        }

        public async Task<IActionResult> Detail(int id) {
            Patient patient = await _PatientService.GetByIdAsync(id);
            return View(patient);
        }
    }
}
