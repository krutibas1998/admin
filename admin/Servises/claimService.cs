using admin.DatabaseEntity;

namespace admin.Servises
{
    public class claimService : IclaimService
    {
        private readonly healthcareContext _healthcareContext;

        public claimService(healthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        public string AddClaim(Claim claim)
        {
            string result = string.Empty;

            try
            {
                _healthcareContext.Claims.Add(claim);
                _healthcareContext.SaveChanges();
                result = "Claim Added";
            }
            catch (Exception Ex)
            {
                result = $"Claim details not saved {Ex.InnerException}";
            }


            return result;
        }

    }
}
