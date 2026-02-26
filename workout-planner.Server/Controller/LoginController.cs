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
        public async Task<IActionResult> checkUserForLogin([FromBody] LoginDTO dto)
        {
            if (dto == null) return BadRequest("Add respective credentials.");

            var userFound = await _db.Users.Where((e) => e.Username == dto.Username && e.Password == dto.Password).FirstOrDefaultAsync();
            
            if(userFound == null) return NotFound("No such user found"); 
                
            var token = await _jwt.GenerateToken(userFound);
            if (token == null) return BadRequest("No token generated, user is null");
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);    //added this cuz we dont want an entire internal object structure generated, we want only the token

            //if written this return Ok(jwtToken); backend sends raw string as the body but front end expects json so return Ok( new {token = jwtToken});

            return Ok(new { token = jwtToken});    

        }

    }
}
