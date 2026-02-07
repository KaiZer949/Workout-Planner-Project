using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using workout_planner.Server.Database;
using workout_planner.Server.DTO;
using workout_planner.Server.JWT;

namespace workout_planner.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DatabaseContext _db;
        private readonly JWTService _jwt;

        public LoginController(DatabaseContext db, JWTService jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        [HttpPost]
        public async Task<ActionResult> checkAuthentication([FromBody] LoginDTO dto)
        {
            if (dto == null) { Console.Write("Empty crendentials"); }
            var foundUser =await _db.Users.Where(e => e.Username == dto.Username && e.Password == dto.Password).FirstOrDefaultAsync();

            var token =await _jwt.GenerateToken(foundUser);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(new {token = jwtToken});
        }
    }
}
