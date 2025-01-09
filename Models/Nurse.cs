using System.ComponentModel.DataAnnotations;

namespace HealthHub1.Models {
    public class Nurse {
        [Key]
        public int NurseId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(15)]
        public string ContactNumber { get; set; }
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
        public virtual ICollection<PatientNurse> PatientNurses { get; set; }
        public virtual ICollection<PatientHistory> PatientHistories { get; set; }
    }

}
