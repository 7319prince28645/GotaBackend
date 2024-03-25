using ApiGotadevida.Entitys;
using Microsoft.EntityFrameworkCore;

namespace ApiGotadevida.DbContexts
{
    public class GotaAGotaContext : DbContext
    {
        public GotaAGotaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users => Set<Users>();
        public DbSet<UserProfile> Profiles => Set<UserProfile>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.Id); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
