using BasicRazorPage.Core;
using Microsoft.EntityFrameworkCore;

namespace BasicRazorApp.Data
{
    public class BasicRazorAppDataContext : DbContext
    {
        public BasicRazorAppDataContext(DbContextOptions<BasicRazorAppDataContext> options)
    : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}