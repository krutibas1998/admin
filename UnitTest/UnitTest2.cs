
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenBaseAuth.Controllers;
using TokenBaseAuth.DatabaseEntity;
using TokenBaseAuth.Services;

namespace UnitTest
{
    public class UnitTest2
    {
        [TestMethod]

        public void Authenticate_Test()
        {
            var connectionstring = "Data Source=CTSDOTNET673;Initial Catalog=healthcare;User ID=sa;Password=pass@word1";
            var optionsBuilder = new DbContextOptionsBuilder<healthcareContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            var Context = new healthcareContext(optionsBuilder.Options);
            var authenticate = new Authentication(Context);
            var tokenService = new TokenService();

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            // Duplicate here any configuration sources you use.
            configurationBuilder.AddJsonFile("AppSettings.json");
            IConfiguration configuration = configurationBuilder.Build();

            var obj = new AuthenticationController(configuration, Context, tokenService, authenticate);
            var request = new UserRegistration();
            var result = obj.Authenticate(request);
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.Value));
        }

    }
}
