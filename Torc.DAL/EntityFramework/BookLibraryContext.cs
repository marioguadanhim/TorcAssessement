using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torc.DAL.EntityFramework
{
    public class BookLibraryContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Book> Book { get; set; }

        public BookLibraryContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetSection("ConnectionString").Value);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapping
            modelBuilder.ApplyConfiguration(new BookMapping());
        }
    }
}
