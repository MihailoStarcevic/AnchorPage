using AnchorPage.Application.Exceptions;
using AnchorPage.DataAccess;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace AnchorPage.API.Core
{
    public class JwtManager
    {
        private readonly AnchorPageContext _context;
        private readonly string _issuer;
        private readonly string _secretKey;

        public JwtManager(AnchorPageContext context, string issuer, string secretKey)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
        }

        public string MakeToken(string userLogin, string password)
        {
            string? userPassword = _context.Users
                .Where(x => x.Email == userLogin || x.Username == userLogin)
                .Select(x => x.Password)
                .FirstOrDefault();

            if (userPassword == null)
                return null;

            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(password, userPassword);

            if (!isPasswordMatch)
                return null;

            var user = _context.Users.FirstOrDefault(x => (x.Email == userLogin || x.Username == userLogin) && isPasswordMatch);

            var allowedUseCasesIds = _context.RoleUseCases
                .Where(ruc => ruc.RoleId == user.RoleId)
                .Select(ruc => ruc.UseCaseId)
                .ToList();

            var actor = new JwtActor
            {
                Id = user.Id,
                AllowedUseCases = _context.UseCases
                    .Where(uc => allowedUseCasesIds.Contains(uc.Id))
                    .Select(uc => uc.Id),
                Identity = user.Username
            };

            var issuer = _issuer;
            var secretKey = _secretKey;
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer, ClaimValueTypes.String, issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, issuer),
                new Claim("ActorData", JsonConvert.SerializeObject(actor), ClaimValueTypes.String, issuer)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
