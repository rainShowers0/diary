using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LessonAspIdentity18.Models
{
    public class UContext:IdentityDbContext
    {
        public UContext(DbContextOptions<UContext> options):base(options) 
        {
            
        }   

        public DbSet<Post> Posts { get; set; }
    }
}
