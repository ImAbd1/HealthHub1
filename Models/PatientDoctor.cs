using Microsoft.EntityFrameworkCore;

namespace HealthHub1.Models {
    [PrimaryKey(nameof(PatientId), nameof(DoctorId))]

    public class PatientDoctor {
        public int PatientId { get; set; } // Foreign key
        public int DoctorId { get; set; } // Foreign key

        // Navigation properties
        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }

}
