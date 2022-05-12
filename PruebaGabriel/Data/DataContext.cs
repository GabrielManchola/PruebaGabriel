using Microsoft.EntityFrameworkCore;
using PruebaGabriel.Models;

namespace PruebaGabriel.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<OwnerModel> Owner { get; set; }

    }
}
