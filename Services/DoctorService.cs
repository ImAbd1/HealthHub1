using HealthHub1.Data;
using HealthHub1.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub1.Services {
    public class DoctorService {
        private readonly ApplicationDbContext _context;

        int DoctorID;
        String Name;
        String Department;

        public DoctorService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task AddDoctor(Doctor doctor) {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();  // Save changes asynchronously
        }

        // Async method to get a doctor
        public async Task<Doctor> GetDoctor(int doctorId) {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId == doctorId);  // Fetch doctor asynchronously
        }
    }
}
