using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opt) : base(opt) { }


        // db sets // 
        public DbSet<User> Users { get; set; }

    }
}
