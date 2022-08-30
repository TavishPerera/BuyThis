using BuyThis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuyThis.Data
{
    public class BuyThisContext : IdentityDbContext<User>
    {
        public BuyThisContext(DbContextOptions<BuyThisContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}