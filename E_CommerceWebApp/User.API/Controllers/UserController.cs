using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.API.Models;
using User.API.Repositories.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<UserModel> GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<UserModel> CreateUser(UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            var createdUser = _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserModel user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            var updated = _userRepository.UpdateUser(user);
            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deleted = _userRepository.DeleteUser(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
