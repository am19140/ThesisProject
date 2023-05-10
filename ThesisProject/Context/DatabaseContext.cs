
using Microsoft.EntityFrameworkCore;
using ThesisProject.Models;

namespace ThesisProject.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<UserModel> users { get; set; }
        public DbSet<SongModel> songs { get; set; }
        public DbSet<LikedModel> likes { get; set; }
        public DbSet<HistoryModel> history { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>().Property(x => x.username)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<SongModel>().Property(x => x.songId).IsRequired();
            modelBuilder.Entity<HistoryModel>().Property(x => x.id).IsRequired();
            modelBuilder.Entity<LikedModel>().Property(x => x.id).IsRequired();

        }
    }
}
