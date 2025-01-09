using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthHub1.Models {

    public class Patient {
        [Key]
        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public String? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ContactNumber { get; set; }

        [ForeignKey("Bed")]
        public int? BedId { get; set; } // Foreign key

        public DateTime? AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; } // Nullable
        public string? Status { get; set; } // Active, Discharged

        // Navigation properties
        public virtual Bed? Bed { get; set; }

        public virtual ICollection<PatientHistory>? PatientHistories { get; set; }

        public virtual ICollection<PatientDoctor>? PatientDoctors { get; set; }

        public virtual ICollection<PatientNurse>? PatientNurses { get; set; }
    }


}