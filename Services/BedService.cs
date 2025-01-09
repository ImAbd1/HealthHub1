using HealthHub1.Data;
using HealthHub1.Data.Enum;
using HealthHub1.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub1.Services {
    public class BedService {
        private readonly ApplicationDbContext _context;  // Assuming you're using EF to interact with the DB

        public BedService(ApplicationDbContext context) {
            _context = context;
        }

        public void AssignBed(int bedId, int patientId) {
            // Find the bed by its ID
            var bed = _context.Beds.FirstOrDefault(b => b.BedId == bedId);

            // TODO : Add error handling
            if (bed == null) {
                throw new Exception("Bed not found.");
            }

            if (bed.BedStatus != BedStatus.Available) {
                throw new Exception("Bed is not available.");
            }

            // Find the patient by their ID
            var patient = _context.Patients.FirstOrDefault(p => p.PatientId == patientId);

            if (patient == null) {
                throw new Exception("Patient not found.");
            }

            // Assign the bed to the patient
            patient.BedId = bedId;
            bed.BedStatus = BedStatus.Unavailable;
            bed.Patient = patient;

            // Save changes to the database
            _context.SaveChanges();
        }


        public async Task<IEnumerable<Bed>> GetAvailableBeds() {
            return await _context.Beds
                .Where(b => b.BedStatus == BedStatus.Available)
                .ToListAsync();
        }

        public async Task<IEnumerable<Bed>> GetOccupiedBeds() {
            return await _context.Beds
                .Include(b => b.Patient)
                .Where(b => b.BedStatus == BedStatus.Unavalaible)
                .ToListAsync();
        }

        public async Task<double> GenerateBedOccupancyRate(string category) {
            var totalBeds = _context.Beds
                .Where(b => b.Category == category)
                .Count();

            var occupiedBeds = await GetOccupiedBeds();

            var occupiedBedsInCategory = occupiedBeds
                .Where(b => b.Category == category)
                .Count();

            if (totalBeds == 0) return 0;

            return (double) occupiedBedsInCategory / totalBeds * 100;
        }

        public async Task MarkAvailable(int? bedId) {
            var bed = await _context.Beds.FindAsync(bedId);
            if (bed != null) {
                bed.BedStatus = BedStatus.Available;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkUnavailable(int? bedId) {
            var bed = await _context.Beds.FindAsync(bedId);
            if (bed != null) {
                bed.BedStatus = BedStatus.Unavalaible;
                await _context.SaveChangesAsync();
            }

        }

    }
}

