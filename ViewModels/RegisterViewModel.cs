namespace HealthHub1.ViewModels {
    public class RegisterViewModel {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ContactNumber { get; set; }
        public string Specialization { get; set; }
        public string Position { get; set; } // "Doctor" or "Nurse"
    }
}
