using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workout_planner.Server.Database;
using workout_planner.Server.Entities;

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
        public IActionResult AddUsers()
        {
            return null;
        }

        [HttpPatch]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateUser()
        {
            return null;
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult DeleteUser()
        {
            return null;
        }
        
    }
}
