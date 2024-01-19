using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProofOfConceptBLZ.Data
{
    public class DataContext : IdentityDbContext<ProofOfConceptBLZ.Data.ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
