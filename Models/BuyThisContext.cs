using BuyThis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuyThis.Data
{
    public class BuyThisContext : IdentityDbContext<User>
    {
        ////private readonly IConfiguration _config;

        //public BuyThisContext(IConfiguration config)
        //{
        //    _config = config;
        //}

        public BuyThisContext(DbContextOptions<BuyThisContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        //public DbSet<User> Users { get; set; }


        public DbSet<Login> Logins { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        //{
        //    base.OnConfiguring(dbContextOptionsBuilder);

        //    dbContextOptionsBuilder.UseSqlServer(_config["ConnectionStrings:BuyThisContext"]);
        //}

    }
}
