using UserAPI.Models;

namespace UserAPI.Interfaces
{
    public interface IGeneratePassword
    {
        public Task<string?> GeneratePassword(Intern intern);
    }
}
