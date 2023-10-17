using ABTest.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ABTest.API.Data
{
    public class TestDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public TestDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
