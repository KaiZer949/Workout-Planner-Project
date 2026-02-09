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
    }
}
