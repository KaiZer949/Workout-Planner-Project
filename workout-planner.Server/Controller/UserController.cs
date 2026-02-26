using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workout_planner.Server.Database;
using workout_planner.Server.DTO;
using workout_planner.Server.Models;

namespace workout_planner.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DatabaseContext _db;

        public UserController(DatabaseContext db) { 
        
            _db = db;
        
        }

        [Route("getData")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public List<Users> GetUser()
        {
            return _db.Users.ToList();
        }
 
        [HttpPost]
        [Route("AddUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> AddUsers([FromBody] UserDTO user)
        {
            if (user == null) return BadRequest("No user to add");
        
            var newUser = new Users()
            {
                Name = user.Name,
                Username = user.UserName,
                Password = user.Password,
                Roles = user.Role,

            };

            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();

            return Ok("User Added successfully");

        }

        [HttpPatch]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult UpdateUser()
        {
            return null;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if(id == null)  return BadRequest("No id is passed"); 

            var user =  await _db.Users.Where((e) => e.Id == id).FirstOrDefaultAsync();
            if (user == null) return NotFound($"No User with id:{id} found"); 

            _db.Users.Remove(user);
            await _db.SaveChangesAsync();

            return Ok($"User with id:{id} removed successfully");
        }
        
    }
}
