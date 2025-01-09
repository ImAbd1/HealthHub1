using HealthHub1.Models;
using HealthHub1.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub1.Controllers {
    public class DischargeController : Controller {
        private readonly PatientService _PatientService;
        public DischargeController(PatientService patientService, BedService bedService) {
            _PatientService = patientService;
        }

        public async Task<IActionResult> Index() {
            IEnumerable<Patient> patients = await _PatientService.GetAllPatients();
            return View(patients);
        }

        public IActionResult discharge(int patientID) {
            _PatientService.DischargePatient(patientID);
            return RedirectToAction("Index");
        }
    }
}
