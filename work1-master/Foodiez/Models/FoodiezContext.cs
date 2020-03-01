using Microsoft.EntityFrameworkCore;
using Foodiez.Models;

namespace Foodiez.Models
{
    public class FoodiezContext : DbContext
    {
        public FoodiezContext(DbContextOptions<FoodiezContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<FoodItem> FoodItem { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> CartOrderItemIds { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public object CartOrderItems { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed FoodItem
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 1, Name = "Pasta", Quantity = 5, UnitPrice = 50, CategoryId = 1 });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 2, Name = "Paratha", Quantity = 5, UnitPrice = 50, CategoryId = 2 });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 3, Name = "Raiyta", Quantity = 5, UnitPrice = 50, CategoryId = 2 });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 4, Name = "Roti", Quantity = 5, UnitPrice = 50, CategoryId = 3 });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 5, Name = "Poha", Quantity = 15, UnitPrice = 40, CategoryId = 2 });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 6, Name = "Dosa", Quantity = 15, UnitPrice = 35, CategoryId = 3});
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 7, Name = "Naan", Quantity = 5, UnitPrice = 50, CategoryId = 2 });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 8, Name = "Rajma", Quantity =7, UnitPrice = 40, CategoryId = 3 });
            modelBuilder.Entity<FoodItem>().HasData(new FoodItem { Id = 9, Name = "Kari", Quantity = 6, UnitPrice = 35, CategoryId = 3});


            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Fast Food" ,Description="The food which have much fat"});
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Normal Food" ,Description="The food mostly liked by indians"});
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Lunch",Description="The food specialy eat on afternoon" });


        }

        public DbSet<Foodiez.Models.CartOrderItem> CartOrderItem { get; set; }

       

    }
}