using AnimalShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

namespace AnimalShop.Data
{
    public class AuthenticationContext : IdentityDbContext<IdentityUser>
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedUsers(builder);
        }

        private void SeedUsers(ModelBuilder builder)
        {


            builder.Entity<IdentityUser>().HasData(

                  new IdentityUser()
                  {
                      Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                      UserName = "Admin",
                      NormalizedUserName = "Admin",
                      PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "#HelloWorld2023"),
                  }
                );
        }

    }
}
