using AutorisationService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AutorisationService.data
{
    public class AutorisationDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        public AutorisationDbContext(DbContextOptions<AutorisationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }
    public DbSet<User> AutUsers {  get; set; }
    }
}
