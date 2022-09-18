using admin.Controllers;
using admin.DatabaseEntity;
using admin.Servises;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Configuration;
using TokenBaseAuth.DatabaseEntity;
using TokenBaseAuth.Services;
using healthcareContext = admin.DatabaseEntity.healthcareContext;
using User = admin.DatabaseEntity.User;
using UserRegistration = admin.DatabaseEntity.UserRegistration;


namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
       
       
        [TestMethod]
        public void GetUser_Test()
        {

            var connectionstring = "Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1";

            var optionsBuilder = new DbContextOptionsBuilder<healthcareContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            var dBContext = new healthcareContext(optionsBuilder.Options);
            var iclaimService = new claimService(dBContext);
            var iuserServices = new userServices(dBContext);
            var obj = new AdminController(iuserServices, dBContext, iclaimService);
            var result = obj.GetUser();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());

        }
        [TestMethod]
        public void insertUser_Test()
        {
            var connectionstring = "Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1";

            var optionsBuilder = new DbContextOptionsBuilder<healthcareContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            var dBContext = new healthcareContext(optionsBuilder.Options);
            var iclaimService = new claimService(dBContext);
            var iuserServices = new userServices(dBContext);
            var obj = new AdminController(iuserServices, dBContext, iclaimService);
            var user = new User();
            var result = obj.insertUser(user);
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.Value));
        }

        [TestMethod]

         public void insertClaim_Test()
         {
            var connectionstring = "Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1";

            var optionsBuilder = new DbContextOptionsBuilder<healthcareContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            var dBContext = new healthcareContext(optionsBuilder.Options);
            var iclaimService = new claimService(dBContext);
            var iuserServices = new userServices(dBContext);
            var obj = new AdminController(iuserServices, dBContext, iclaimService);
            var claim = new Claim();
            var result = obj.insertClaim(claim);
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.Value));
         }

        [TestMethod]
        public void SearchUser_Test()
        {
            var connectionstring = "Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1";

            var optionsBuilder = new DbContextOptionsBuilder<healthcareContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            var dBContext = new healthcareContext(optionsBuilder.Options);
            var iclaimService = new claimService(dBContext);
            var iuserServices = new userServices(dBContext);
            var obj = new AdminController(iuserServices, dBContext, iclaimService);
            var user = new User();
            var result = obj.SearchUser(user);
            Assert.IsNotNull(result);
           
        }
        [TestMethod]
        public void insertUser_Test1()
        {
            var connectionstring = "Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1";
            var optionsBuilder = new DbContextOptionsBuilder<healthcareContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            var dBContext = new healthcareContext(optionsBuilder.Options);
            var iuserRegistrationService = new userRegistrationService(dBContext);
            var obj = new userRegistrationController(iuserRegistrationService, dBContext);
            var userRegistration = new UserRegistration();
            var result = obj.insertUser(userRegistration);
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.Value));
        }

        //[TestMethod]

        //public void Authenticate_Test()
        //{
        //    var connectionstring = "Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1";
        //    var optionsBuilder = new DbContextOptionsBuilder<healthcareContext>();
        //    optionsBuilder.UseSqlServer(connectionstring);
        //    var Context = new healthcareContext(optionsBuilder.Options);
        //    var authenticate = new Authentication(Context);
        //    var tokenService = new TokenService();
        //    var obj = new AuthenticationController(Context, authenticate, tokenService);
        //}



    }
}