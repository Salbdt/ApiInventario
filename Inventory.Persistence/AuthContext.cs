using Inventory.Entities;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Persistence
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}