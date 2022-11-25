using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIApps.Models
{
    public class SecurityCodiDbContext : IdentityDbContext<IdentityUser>
    {
        public SecurityCodiDbContext(DbContextOptions<SecurityCodiDbContext> options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
