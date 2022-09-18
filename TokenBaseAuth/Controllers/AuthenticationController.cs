using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TokenBaseAuth.DatabaseEntity;
using TokenBaseAuth.Services;

namespace TokenBaseAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        public readonly healthcareContext _context;

        public readonly ITokenService _tokenService;

        public readonly IConfiguration _configuration;

        public readonly IAuthentication _authenticate;

        public AuthenticationController(IConfiguration configuration, healthcareContext context, ITokenService tokenService, IAuthentication authenticate)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _context = context;
            _tokenService = tokenService;
            _authenticate = authenticate;
        }

        [HttpPost]
        public ActionResult<string> Authenticate(UserRegistration request)
        {
            var user = _authenticate.ValidateUserCredentials(request.UserName == null ? "" : request.UserName, request.Password == null ? "" : request.Password);
            if (user.UserName != null)
            {
                String token = _tokenService.BuildToken(_configuration["Authentication:SecretForKey"],
                    _configuration["Authentication:Issuer"],
                    new[]
                    {
                        _configuration["Authentication:Aud1"],
                        _configuration["Authentication:Aud2"],
                        //_configuration["Authentication:Aud3"]
                    },

                    request.UserName == null ? "" : request.UserName, user
                    );
                string userRole = _context.UserRegistrations.Where(user => user.UserName == request.UserName).Select(user => user.UserType).FirstOrDefault();
                //return Ok(token);
                return Ok(new
                    {
                        Token = token,
                        Role = userRole
                    });
               
            }
            else
            {
                return Ok(new {Token = "Invalid Credentials" });
            }
        }
    }
}
