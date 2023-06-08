using UserAPI.Models;
using UserAPI.Models.DTO;

namespace UserAPI.Interfaces
{
    public interface IManageUser
    {
        public Task<UserDTO> Login(UserDTO user);
        public Task<UserDTO> Register(InternDTO intern);
        public Task<User> ChangeStatus(User user);
        public Task<ICollection<Intern>> GetInterns();
        public Task<bool> ChangePassword(PasswordDTO passwordDTO);
    }
}
