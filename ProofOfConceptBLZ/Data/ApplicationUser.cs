using Microsoft.AspNetCore.Identity;

namespace ProofOfConceptBLZ.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string CompanyID { get; set; }
    }
}

