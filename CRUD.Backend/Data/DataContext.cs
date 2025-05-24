using CRUD.Shared;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; } 
    }
    
    
}
