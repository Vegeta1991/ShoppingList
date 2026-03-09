

namespace ShoppingList.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<ShoppingItem> ShoppingItems { get; set; }

    }
}
