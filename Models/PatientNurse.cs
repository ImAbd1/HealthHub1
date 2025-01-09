using Microsoft.EntityFrameworkCore;

namespace HealthHub1.Models {
    [PrimaryKey(nameof(PatientId), nameof(NurseId))]
    public class PatientNurse {
        public int PatientId { get; set; } // Foreign key

        public int NurseId { get; set; } // Foreign key

        // Navigation properties
        public virtual Patient Patient { get; set; }
        public virtual Nurse Nurse { get; set; }
    }
}
