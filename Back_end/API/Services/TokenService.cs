using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Data.Entities;
using API.Repositories;
using API.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;

        public TokenService(IConfiguration configuration, IUserRepository repository)
        {
            _configuration = configuration;
            _repository = repository;
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Username),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.Firstname + " " +user.LastName),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Avatar),
                new Claim(ClaimTypes.Role, _repository.GetRolesOfUser(user.Id).Name),
            };

            var symmetricKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    symmetricKey, SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
 
            var token = tokenHandler.CreateToken(tokenDescriptor);
 
            return tokenHandler.WriteToken(token);
        }
    }
}