using admin.DatabaseEntity;
using admin.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userRegistrationController : ControllerBase
    {
        private readonly healthcareContext dBContext;
        private readonly IuserRegistrationService _iuserRegistrationService;

        public userRegistrationController(IuserRegistrationService iuserRegistrationService, healthcareContext dBContext)
        {
            _iuserRegistrationService = iuserRegistrationService;
            this.dBContext = dBContext;
        }

        [HttpPost("LogIn")]
        public ActionResult<UserRegistration> Login([FromBody] UserRegistration userRegistration)
        {
           return  _iuserRegistrationService.Login(userRegistration, userRegistration.UserName, userRegistration.Password);

            
        }

        [HttpPost("insertUser")]
        public ActionResult<string> insertUser([FromBody] UserRegistration userRegistration)
        {

            string result = _iuserRegistrationService.AddUser(userRegistration, userRegistration.UserName);


            return Ok(result);
        }
    }
}
