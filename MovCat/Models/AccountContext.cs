using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovCat.Models
{
    public class AccountContext : IdentityDbContext<AppUser>
    {
        public AccountContext(DbContextOptions<AccountContext> options) : base(options) => Database.EnsureCreated();
    }
}
