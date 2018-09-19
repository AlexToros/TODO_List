using System.Data.Entity;

namespace TestExersize.Models
{
    public class EFDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<AppUser> Users { get; set; }
    }
}