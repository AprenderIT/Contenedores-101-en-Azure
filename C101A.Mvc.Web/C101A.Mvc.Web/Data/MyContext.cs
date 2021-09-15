using Microsoft.EntityFrameworkCore;

namespace C101A.Mvc.Web.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        { }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Website> Websites { get; set; }
    }
}
