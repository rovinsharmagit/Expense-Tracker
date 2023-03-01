
using Microsoft.EntityFrameworkCore;
using my_expenses.Models;

namespace my_expenses.Data
{
    public class AppDataContext:DbContext
    {
        public AppDataContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
