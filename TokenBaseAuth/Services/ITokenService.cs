using TokenBaseAuth.DatabaseEntity;

namespace TokenBaseAuth.Services
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, IEnumerable<string> audience, string UserName, UserRegistration userRegistration);
    }
}