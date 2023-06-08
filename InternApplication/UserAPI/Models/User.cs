using System.ComponentModel.DataAnnotations;

namespace UserAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordKey { get; set; }
        public string? UserRole { get; set; }
        public string? UserStatus { get; set; }
    }
}
