using Microsoft.EntityFrameworkCore;
using PrologMobile.Data;
using System.Collections.Generic;

namespace PrologMobile.Models
{

    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options)
            : base(options) { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }

        // Other db sets and configurations
    }

}
