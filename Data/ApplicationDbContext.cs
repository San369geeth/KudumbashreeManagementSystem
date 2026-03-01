using KudumbashreeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace KudumbashreeManagementSystem.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingMember> MeetingMembers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MeetingMember>()
            .Property(m => m.ContributionAmount)
            .HasPrecision(12, 2);
            modelBuilder.Entity<Meeting>()
                .Property(c => c.ExpectedAmount)
                .HasPrecision(12, 2);
        }
    }
}
