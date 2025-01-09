using HealthHub1.Data;
using HealthHub1.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub1.Services {
    public class NurseService {
        private readonly ApplicationDbContext _context;

        int nurseID;
        String Name;
        String Department;

        public NurseService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task AddNurse(Nurse nurse) {
            await _context.Nurses.AddAsync(nurse);
            await _context.SaveChangesAsync();
        }

        public async Task<Nurse> GetNurse(int nurseId) {
            return await _context.Nurses.FirstOrDefaultAsync(n => n.NurseId == nurseId);
        }
    }
}
