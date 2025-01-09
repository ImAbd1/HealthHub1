using HealthHub1.Models;
using HealthHub1.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthHub1.Controllers {
    public class HomeController : Controller {
        private readonly PatientService _PatientService;
        private readonly BedService _bedService;
        public HomeController(PatientService patientService, BedService bedService) {
            _PatientService = patientService;
            _bedService = bedService;
        }

        public async Task<IActionResult> Index() {
            IEnumerable<Patient> patients = await _PatientService.GetAllPatients();
            return View(patients);
        }

        public async Task<IActionResult> PatientInfo(int id) {
            Patient patient = await _PatientService.GetByIdAsync(id);
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatient(Patient model) {
            if (ModelState.IsValid) {
                // Retrieve the patient from the database by ID
                var patient = await _PatientService.GetByIdAsync(model.PatientId);

                if (patient != null) {
                    // Update patient details
                    patient.FirstName = model.FirstName;
                    patient.LastName = model.LastName;
                    patient.DateOfBirth = model.DateOfBirth;
                    patient.ContactNumber = model.ContactNumber;
                    patient.Gender = model.Gender;
                    patient.BedId = model.BedId;
                    patient.AdmissionDate = model.AdmissionDate;
                    patient.DischargeDate = model.DischargeDate;

                    //TODO : PATIENT HISTORY HANDLE
                    patient.PatientHistories = model.PatientHistories;

                    // Save the updated patient info to the database
                    await _PatientService.UpdatePatient(patient);

                    // Redirect to a success page or back to the patient's info page
                    return RedirectToAction("PatientInfo", new { id = patient.PatientId });
                }

                // If patient is not found, return to the patient info page with an error
                ModelState.AddModelError("", "Patient not found.");
            }

            // If the model state is invalid, return to the same page with validation errors
            return View(model);
        }

    }
}
