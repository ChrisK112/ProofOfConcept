using Microsoft.AspNetCore.Identity;

namespace ProofOfConceptBLZ.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int CompanyID { get; set; }
    }
}

