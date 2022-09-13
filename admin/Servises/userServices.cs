using admin.DatabaseEntity;
using Microsoft.AspNetCore.Connections;

namespace admin.Servises
{
    public class userServices : IuserServices
    {
        private readonly healthcareContext _healthcareContext;

        public userServices(healthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }



        public string AddUser(User user, string email)
        {
            string result = string.Empty;
            var item = _healthcareContext.Users.Where(x => x.Email == email).FirstOrDefault();
            if (item != null)
            {
                result = "User exsits";
            }
            else
            {
                try
                {
                    _healthcareContext.Users.Add(user);
                    _healthcareContext.SaveChanges();
                    result = "User Added";
                }
                catch (Exception Ex)
                {
                    result = $"User details not saved {Ex.InnerException}";
                }
            }

            return result;
        }



        public object SearchUser(User user)
        {

          var item = _healthcareContext.Users.ToList().Where(x => (x.UserId == user.UserId)||x.FirstName==user.FirstName).ToList();
            var result = from u in _healthcareContext.Users
                         join c in _healthcareContext.Claims
                         on
                         u.UserId equals c.ClaimId into ts from t in ts.DefaultIfEmpty()
                         where u.UserId == user.UserId  
                         select new
                         {
                             memberId = u.UserId,
                             firstName = u.FirstName,
                             lastName = u.LastName,
                             physician = u.Physician,
                             claimId = t.ClaimId == null ? 0 : (t.ClaimId),
                             claimAmmount = t.ClaimAmmount,
                             claimDate = t.ClaimDate,
                         };
            return result;

        }

        


    }
}
