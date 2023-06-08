using UserAPI.Models.DTO;

namespace UserAPI.Interfaces
{
    public interface IGenerateToken 
    {
        public string GenerateToken(UserDTO user);
    }
}
