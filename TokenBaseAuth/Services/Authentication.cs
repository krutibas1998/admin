using TokenBaseAuth.DatabaseEntity;

namespace TokenBaseAuth.Services
{
    public class Authentication : IAuthentication
    {
        public readonly healthcareContext _context;

        public Authentication(healthcareContext context)
        {
            _context = context;
        }

        public UserRegistration ValidateUserCredentials(string username, string password)
        {
            var userdata = _context.UserRegistrations.Where(s => s.UserName == username && s.Password == password);
            if (userdata.Count() == 0)
            {
                return new UserRegistration();
            }
            return userdata.First();
        }
    }
}
