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
    }
}
