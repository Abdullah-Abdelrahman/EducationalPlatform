using System.Security.Claims;

namespace EducationalPlatform.Data.Helpers
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Create Course","false"),
            new Claim("Edit Course","false"),
            new Claim("Delete Course","false"),
        };
    }
}
