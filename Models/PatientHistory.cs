using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthHub1.Models {

    public class PatientHistory {
        [Key]
        public int HistoryId { get; set; }
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; } // Foreign key
        [ForeignKey("AddedByDoctor")]
        public int? AddedByDoctorId { get; set; } // Foreign key (nullable)
        [ForeignKey("AddedByNurse")]
        public int? AddedByNurseId { get; set; } // Foreign key (nullable)
        [Required]
        [StringLength(1000)]
        public string Notes { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }

        // Navigation properties
        public virtual Patient Patient { get; set; }
        public virtual Doctor AddedByDoctor { get; set; }
        public virtual Nurse AddedByNurse { get; set; }
    }

}
