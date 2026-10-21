namespace LqtThlap2.Models
{
    public class LqtStudent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public LqtBranch? Branch { get; set; }
        public LqtGender? Gender { get; set; }
        public bool IsRegular { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBorth { get; set; }
    }
}
