
using HealthHub1.Data;
using HealthHub1.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub1.Services {
    public class PatientService {

        private readonly ApplicationDbContext _context;
        public PatientService(ApplicationDbContext context) {
            this._context = context;
        }

        // Fields
        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public String? BedID { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string? Status { get; set; }

        public void AddPatient(Patient patient) {
            // Create a new patient instance
            var newPatient = new Patient {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                ContactNumber = patient.ContactNumber,
                Gender = patient.Gender,
                AdmissionDate = DateTime.Now,
                Status = "Active"
            };

            _context.Patients.Add(newPatient);

            BedService bedService = new BedService(_context);

            // Assign the bed to the patient if BedId is provided
            if (patient.BedId.HasValue) {
                bedService.AssignBed(patient.BedId.Value, newPatient.PatientId);
            }
            _context.SaveChanges();
        }
        public async Task<IEnumerable<Patient>> GetAllPatients() {
            return await _context.Patients.Include(p => p.Bed).ToListAsync();
        }

        public async Task<Patient?> GetByIdAsync(int id) {
            return await _context.Patients.FirstOrDefaultAsync(i => i.PatientId == id);
        }


        // Method to update patient details
        public async Task UpdatePatient(Patient patient) {
            var existingPatient = await _context.Patients.FirstOrDefaultAsync(p => p.PatientId == patient.PatientId);

            if (existingPatient != null) {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.DateOfBirth = patient.DateOfBirth;
                existingPatient.ContactNumber = patient.ContactNumber;
                existingPatient.Gender = patient.Gender;
                existingPatient.BedId = patient.BedId;
                existingPatient.AdmissionDate = patient.AdmissionDate;
                existingPatient.DischargeDate = patient.DischargeDate;
                existingPatient.PatientHistories = patient.PatientHistories;

                await _context.SaveChangesAsync();
            }
        }



        // Method to discharge a patient
        public void DischargePatient(int patientId) {
            var patient = _context.Patients.FirstOrDefault(p => p.PatientId == patientId);
            if (patient != null) {
                patient.Status = "Discharged";
                BedService bedService = new BedService(_context);
                bedService.MarkAvailable(patient.BedId);
                patient.Bed.BedId = 0;
                _context.SaveChanges();
            }
        }

        // Method to search patients by input (name or ID)


        //// Method to search patients by name
        //public List<PatientService> SearchPatientByName(string name) {
        //    return patients.Where(p =>
        //        p.FirstName.Contains(name, StringComparison.OrdinalIgnoreCase) ||
        //        p.LastName.Contains(name, StringComparison.OrdinalIgnoreCase)
        //    ).ToList();
        //}

        //// Method to search patients by identifier (ID as string)
        //public List<PatientService> SearchPatientByIdentifier(string id) {
        //    return patients.Where(p => p.PatientID.ToString() == id).ToList();
        //}

    }

}