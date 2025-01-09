using HealthHub1.Data.Enum;
using HealthHub1.Models;
using Microsoft.AspNetCore.Identity;

namespace HealthHub1.Data {
    public class Seed {
        public static void SeedData(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (context == null) {
                    throw new InvalidOperationException("Database context is null.");
                }

                context.Database.EnsureCreated();  // or use Migrate() if using migrations

                // Seed Nurses
                if (!context.Nurses.Any()) {
                    var passwordHasher = new PasswordHasher<Nurse>();

                    context.Nurses.AddRange(new List<Nurse>()
                    {
                        new Nurse { Name = "Alice Green", ContactNumber = "1234567890", Specialization = "ICU", Email = "alice.green@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                        new Nurse { Name = "Bob Blue", ContactNumber = "0987654321", Specialization = "Emergency", Email = "bob.blue@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                        new Nurse { Name = "Catherine White", ContactNumber = "1122334455", Specialization = "General Ward", Email = "catherine.white@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                        new Nurse { Name = "David Black", ContactNumber = "6677889900", Specialization = "ICU", Email = "david.black@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                        new Nurse { Name = "Emma Brown", ContactNumber = "5566778899", Specialization = "General Ward", Email = "emma.brown@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                    });
                    context.SaveChanges();
                }

                // Seed Doctors
                if (!context.Doctors.Any()) {
                    var passwordHasher = new PasswordHasher<Doctor>();

                    context.Doctors.AddRange(new List<Doctor>()
                    {
                        new Doctor { Name = "Dr. Smith", Specialization = "Cardiology", Email = "dr.smith@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                        new Doctor { Name = "Dr. Johnson", Specialization = "Neurology", Email = "dr.johnson@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                        new Doctor { Name = "Dr. Lee", Specialization = "Pediatrics", Email = "dr.lee@healthhub.com", Password = passwordHasher.HashPassword(null, "SecurePass123") },
                    });
                    context.SaveChanges();
                }

                // Seed Beds
                if (!context.Beds.Any()) {
                    var beds = new List<Bed>();
                    for (int i = 1; i <= 5; i++) {
                        beds.Add(new Bed { BedNumber = $"ICU-{i}", Category = "ICU", BedStatus = BedStatus.Available });
                        beds.Add(new Bed { BedNumber = $"GW-{i}", Category = "General Ward", BedStatus = BedStatus.Available });
                        beds.Add(new Bed { BedNumber = $"EMR-{i}", Category = "Emergency", BedStatus = BedStatus.Available });
                    }
                    context.Beds.AddRange(beds);
                    context.SaveChanges();
                }
            }
        }
    }
}
