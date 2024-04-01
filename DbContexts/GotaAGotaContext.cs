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
        public DbSet<PostUser> PostUsers => Set<PostUser>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasOne(u => u.UserProfile)
                .WithOne(up => up.User)
                .HasForeignKey<UserProfile>(up => up.UserId);

            modelBuilder.Entity<Users>()
                .HasMany(u => u.Posts)              // Un usuario tiene muchas publicaciones
                .WithOne(p => p.User)               // Una publicación pertenece a un usuario
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
