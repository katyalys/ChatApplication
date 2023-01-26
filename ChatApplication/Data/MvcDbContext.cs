using ChatApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Data
{
    public class MvcDbContext : DbContext
    {
        public MvcDbContext(DbContextOptions<MvcDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<UsersModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MessageModel>()
                .ToTable("Messages")
                .HasOne<UsersModel>(a => a.UsersModel)
                .WithMany(d => d.Messages);
        }
    }
}
