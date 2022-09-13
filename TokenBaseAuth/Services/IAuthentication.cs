using TokenBaseAuth.DatabaseEntity;

namespace TokenBaseAuth.Services
{
    public interface IAuthentication
    {
        UserRegistration ValidateUserCredentials(string username, string password);
    }
}