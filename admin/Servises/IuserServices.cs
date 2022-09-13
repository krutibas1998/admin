using admin.DatabaseEntity;

namespace admin.Servises
{
    public interface IuserServices
    {
        string AddUser(User user, string email);
        object SearchUser(User user);
    }
}