using admin.DatabaseEntity;
using admin.Servises;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AdminController : ControllerBase
    {
        private readonly healthcareContext dBContext;
        private readonly IuserServices _userServices;
        private readonly IclaimService _iclaimService;

        public AdminController(IuserServices userServices, healthcareContext dBContext, IclaimService iclaimService)
        {
            _userServices = userServices;
            _iclaimService = iclaimService;
            this.dBContext = dBContext;
        }


        [HttpGet]
        public List<User> GetUser()
        {
            return dBContext.Users.ToList();
        }

        [HttpPost("insertUser")]
        public ActionResult<string> insertUser([FromBody] User user)
        {

            string result = _userServices.AddUser(user, user.Email);


            return Ok(result);
        }

        [HttpPost("SearchUser")]
        public object SearchUser([FromBody] User user)
        {
            try
            {
                return _userServices.SearchUser(user);
            }
            catch (Exception ex)
            {
                return new List<User>();
            }
        }

        [HttpPost("insertClaim")]
        public ActionResult<string> insertClaim([FromBody] Claim claim)
        {

            string result = _iclaimService.AddClaim(claim);


            return Ok(result);
        }

    }
}
