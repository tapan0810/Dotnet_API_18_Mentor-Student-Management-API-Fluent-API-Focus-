using Dotnet_API_18.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_18.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Mentor> Mentors => Set<Mentor>();
        public DbSet<Student> Students =>Set<Student>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s =>s.Mentor)
                .WithMany(m=>m.Students)
                .HasForeignKey(s=>s.MentorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
