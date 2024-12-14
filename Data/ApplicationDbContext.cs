using Microsoft.EntityFrameworkCore;
using StudentAppWebAPI.Models.Entities;

namespace StudentAppWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Student> Student { get; set; }
    }
}
