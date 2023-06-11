using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Interfaces;
using UserAPI.Models;
using UserAPI.Models.DTO;

namespace UserAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors(PolicyName = "MyCors")]
    public class UserController : ControllerBase
    {
        private readonly IManageUser _manageUser;

        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register([FromBody] InternDTO intern)
        {
            var result = await _manageUser.Register(intern);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to register at this moment");
        }


        
        [HttpPost]
        public async Task<ActionResult<UserDTO>?> Login([FromBody] UserDTO user)
        {
            var result = await _manageUser.Login(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to login at this moment");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult<UserDTO>?> ChangeStatus([FromBody] User user)
        {
            var result = await _manageUser.ChangeStatus(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to Change Status");
        }

        [HttpPut]
        public async Task<ActionResult<UserDTO>?> ChangePassword([FromBody] PasswordDTO password)
        {
            bool result = await _manageUser.ChangePassword(password);
            if(result)
            {
                return Ok("Password Changed Successfully");
            }
            return BadRequest("Unable to Change Status");
        }
            
        [HttpGet]
        public async Task<ActionResult<ICollection<Intern>>?> GetAllInterns()
        {
            var result = await _manageUser.GetInterns();
            if (result.Count > 1)
            {
                return Ok(result);
            }
            return BadRequest("Unable to Change Status");
        }
    }
}
