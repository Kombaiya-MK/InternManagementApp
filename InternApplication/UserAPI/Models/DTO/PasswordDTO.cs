namespace UserAPI.Models.DTO
{
    public class PasswordDTO
    {
        public int id { get; set; }
        public string? currentPassword { get; set; }
        public string? updatedPassword { get; set; }
        public byte[]? updatedHash { get; set; }
    }
}
