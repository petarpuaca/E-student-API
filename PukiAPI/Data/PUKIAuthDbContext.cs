using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PukiAPI.Data
{
    public class PUKIAuthDbContext : IdentityDbContext
    {
        public PUKIAuthDbContext(DbContextOptions<PUKIAuthDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "3f2d8e5a-1c72-4d42-8c8a-8f14b3e6839d";
            var writerId = "7a5c2f91-a6b4-4d27-92f0-7df612a8e213";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=readerId,
                    ConcurrencyStamp=readerId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper()
                },
                new IdentityRole {
                Id=writerId,
                ConcurrencyStamp =writerId,
                Name="Writer",
                NormalizedName="Writer".ToUpper()

                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
