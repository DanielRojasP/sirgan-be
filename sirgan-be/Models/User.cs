namespace sirgan_be.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName1 { get; set; } = string.Empty;
        public string LastName2 { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string Province { get; set; } = string.Empty;
        public string Canton { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;       
        public string Role { get; set; } = string.Empty;
        public int Status { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
