using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjectStructure.BLL.Interfaces;
using ProjectStructure.Common.DTO.User;

namespace ProjectStructure.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDTO user)
        {
            var createdUser = _userService.AddUser(user);
            return CreatedAtAction("GetById", "users", new { id = createdUser.Id }, createdUser);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(_userService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [HttpPut]
        public IActionResult Put([FromBody] UserDTO user)
        {
            _userService.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}