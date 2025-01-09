namespace HealthHub1.Models {
    using HealthHub1.Data.Enum;
    using System.ComponentModel.DataAnnotations;

    public class Bed {
        [Key]
        public int BedId { get; set; }

        [Required]
        [StringLength(50)]
        public string BedNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(20)]
        public BedStatus BedStatus { get; set; } // Available, Unavailable

        // Navigation properties
        public virtual Patient Patient { get; set; }
    }


}