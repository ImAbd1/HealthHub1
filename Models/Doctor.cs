using System.ComponentModel.DataAnnotations;

namespace HealthHub1.Models {
    public class Doctor {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Specialization { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        // Navigation properties
        public virtual ICollection<PatientDoctor> PatientDoctors { get; set; }

        public virtual ICollection<PatientHistory> PatientHistories { get; set; }
    }

}