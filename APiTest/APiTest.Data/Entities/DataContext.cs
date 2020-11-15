using APiTest.Data.Entities.Data;
using Microsoft.EntityFrameworkCore;

namespace APiTest.Data.Entities
{
    public class DataContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
