using Italo.Customer.Infrastructure.Security;
using Italo.Customer.Infrastructure.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Italo.Customer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IOptions<SecuritySetting> _options;
        private readonly ILogger<SecurityController> _logger;

        public SecurityController(IOptions<SecuritySetting> options, ILogger<SecurityController> logger)
        {
            _options = options;
            _logger = logger;
        }

        /// <summary>
        /// Generate token
        /// </summary>
        /// <param name="userModel">Username and Password</param>
        /// <returns>Token JWT</returns>
        /// <response code="200">Token JWT</response>
        /// <response code="500">Error to generate token</response>
        [HttpPost("generateToken")]
        [Produces("application/text")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [AllowAnonymous]
        public ActionResult GenerateToken(UserModel userModel)
        {
            if (userModel.UserName == "admin" && userModel.Password == "admin")
            {
                var issuer = _options.Value.Issuer;
                var audience = _options.Value.Audience;
                var key = Encoding.UTF8.GetBytes(_options.Value.Key);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, userModel.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, userModel.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }
            return Unauthorized();
        }
    }
}
