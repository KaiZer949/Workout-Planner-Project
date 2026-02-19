using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using workout_planner.Server.Models;

namespace workout_planner.Server.JWT
{
    public class JWTService
    {
        private IConfiguration _config;
        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        //refrence from https://github.dev/PacktPublishing/ASP.NET-Core-6-and-Angular/blob/28d1f2fc973ea280986dc1dc91056147001c14ce/Chapter_11/WorldCities/WorldCitiesAPI/Data/JwtHandler.cs#L24#L34 (suggested by the app itself)

        public async Task<JwtSecurityToken> GenerateToken(Users user)    //generates token using issuer, audience and all listed.....
        {
            var jwtToken = new JwtSecurityToken(

                issuer: _config["jwt:issuer"],
                audience: _config["jwt:audience"],
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_config["jwt:ExpirationTimeInMinutes"])),
                signingCredentials: GetSigningCredentials(),
                claims: await GenerateClaims(user)
            );
            return jwtToken;
        }
        
        private async Task<List<Claim>> GenerateClaims(Users user)    //generates claims to verify the user if the user data is extracted as needed
        {
            var claims = new List<Claim>
                { new Claim(ClaimTypes.Name, user.Username),
                  new Claim(ClaimTypes.Role, user.Roles.ToString())
            };
            return claims;
        }

        private SigningCredentials GetSigningCredentials() {               

            var key = Encoding.UTF8.GetBytes(_config["jwt:secret_key"]);

            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);
        }

    }
}
