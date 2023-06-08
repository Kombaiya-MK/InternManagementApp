using System.Security.Cryptography;
using System.Text;
using UserAPI.Interfaces;
using UserAPI.Models.DTO;
using UserAPI.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace InterUserManagementAPI.Services
{
    public class ManageUserService : IManageUser
    {
        private readonly IRepo<User, int> _userRepo;
        private readonly IRepo<Intern, int> _internRepo;
        private readonly IGeneratePassword _passwordService;
        private readonly IGenerateToken _tokenService;

        public ManageUserService(IRepo<User, int> userRepo,
            IRepo<Intern, int> internRepo,
            IGeneratePassword passwordService,
            IGenerateToken tokenService)
        {
            _userRepo = userRepo;
            _internRepo = internRepo;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }
        public async Task<User> ChangeStatus(User user)
        {
            try
            {
                var updatedUser = await _userRepo.Update(user);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
            return user;
        }

        public async Task<ICollection<User>> GetUsers()
        {
            return await _userRepo.GetAll();
        }

        public async Task<ICollection<Intern>> GetInterns()
        {
            return await _internRepo.GetAll();
        }
        public async Task<UserDTO> Login(UserDTO user)
        {
            var userData = await _userRepo.Get(user.UserId);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.PasswordKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.PasswordHash[i])
                        return null;
                }
                user = new UserDTO();
                user.UserId = userData.UserId;
                user.Role = userData.UserRole;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }

        public bool validatePassword(string currentPassword , User user)
        {
            bool status = true;
            var hmac = new HMACSHA512(user.PasswordKey);
            var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(currentPassword));
            for (int i = 0; i < userPass.Length; i++)
            {
                if (userPass[i] != user.PasswordHash[i])
                    status = false;
            }
            return status;
             
        }
        public async Task<UserDTO> Register(InternDTO intern)
        {

            UserDTO user = null;
            var hmac = new HMACSHA512();
            string? generatedPassword = await _passwordService.GeneratePassword(intern);
            intern.User.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(generatedPassword ?? "1234"));
            intern.User.PasswordKey = hmac.Key;
            intern.User.UserRole = "Intern";
            var userResult = await _userRepo.Add(intern.User);
            var internResult = await _internRepo.Add(intern);
            if (userResult != null && internResult != null)
            {
                user = new UserDTO();
                user.UserId = internResult.Id;
                user.Role = userResult.UserRole;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }


        
        public async Task<bool> ChangePassword(PasswordDTO passwordDTO)
        {
            bool status = false;
            User user = await _userRepo.Get(passwordDTO.id);
            if(validatePassword(passwordDTO.currentPassword , user))
            {
                var hmac = new HMACSHA512();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordDTO.updatedPassword ?? "1234"));
                user.PasswordKey = hmac.Key;
            }
            var result = await _userRepo.Update(user);
            if(result != null)
            {
                return true;
            }
            return status;
            
        }
    }
}