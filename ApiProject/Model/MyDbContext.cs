using Microsoft.EntityFrameworkCore;

namespace ApiProject.Model
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext>opt)  :base(opt) { }
        
        public DbSet<Student> Students { get; set; }
    }
}
