using Microsoft.EntityFrameworkCore;

namespace ChopShop.Api.Dal.UserContext
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
        }
    }
}