using admin.DatabaseEntity;

namespace admin.Servises
{
    public class userRegistrationService : IuserRegistrationService
    {
        private readonly healthcareContext _healthcareContext;

        public userRegistrationService(healthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public string AddUser(UserRegistration userRegistration, string UserName)
        {
            string result = string.Empty;
            var item = _healthcareContext.UserRegistrations.Where(x => x.UserName == UserName).FirstOrDefault();
            if (item != null)
            {
                result = "User exsits";
            }
            else
            {
                try
                {
                    _healthcareContext.UserRegistrations.Add(userRegistration);
                    _healthcareContext.SaveChanges();
                    result = "Account create successful";
                }
                catch (Exception Ex)
                {
                    result = $"User details not saved {Ex.InnerException}";
                }
            }

            return result;
        }

        public UserRegistration Login(UserRegistration userRegistration, string UserName, string Password)
        {
             return _healthcareContext.UserRegistrations.Where(x => x.UserName == UserName && x.Password == Password).First();
            //if (_healthcareContext.UserRegistrations.Where(x => x.UserName == UserName && x.Password == Password).Count() == 0)
            //{
            //    return "Invalid User";
            //}
            //else
            //{
            //    return "Login successful";
            //}
        }
    }
}
