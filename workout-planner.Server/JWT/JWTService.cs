using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using workout_planner.Server.Models;

namespace workout_planner.Server.JWT
{
    public class JWTService
    {
        private readonly IConfiguration _config;
        public JWTService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<JwtSecurityToken> GenerateToken(Users user)    //generates the security token 
        {
            var jwtOptions = new JwtSecurityToken(
                audience: _config["jwt:audience"],
                issuer: _config["jwt:issuer"],
                claims: await generateClaims(user),
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_config["jwt:ExpirationTimeInMinutes"])),
                signingCredentials: getSigningCrentials()
            );
            return jwtOptions;
        }

        private async Task<List<Claim>>generateClaims(Users user)      //This generates the claims 
        {
            var claims = new List<Claim> { new Claim("Username",user.Username),
                                           new Claim(ClaimTypes.Role, user.Roles.ToString())};   
            return claims;
        }

        private SigningCredentials getSigningCrentials()  //we get the signing crentials based 
        {
            var key = Encoding.UTF8.GetBytes(_config["jwt:secret_key"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret,SecurityAlgorithms.HmacSha256);
        }

    }
}
