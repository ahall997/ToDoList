using Microsoft.EntityFrameworkCore;
using AspNetCore.Models;

namespace AspNetCore.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> opt) : base(opt)
        {
            
        }

        public DbSet<Item> Items {get; set; }
    }
}