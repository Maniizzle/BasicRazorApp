using BasicRazorPage.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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