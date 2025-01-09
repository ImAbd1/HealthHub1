using HealthHub1.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthHub1.Data {
    public class ApplicationDbContext : DbContext {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientHistory> PatientHistories { get; set; }
        public DbSet<PatientDoctor> PatientDoctors { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<PatientNurse> PatientNurses { get; set; }
    }
}
