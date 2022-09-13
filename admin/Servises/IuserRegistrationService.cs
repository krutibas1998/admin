using admin.DatabaseEntity;

namespace admin.Servises
{
    public interface IuserRegistrationService
    {
        string AddUser(UserRegistration userRegistration, string UserName);
        UserRegistration Login(UserRegistration userRegistration, string UserName, string Password);
    }
}