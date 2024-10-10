using capiston_team_work_project.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace capiston_team_work_project
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<CommunityPost> CommunityPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-Many: User and Role
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            // One-to-Many: Restaurant and MenuItem
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.MenuItems)
                .WithOne(m => m.Restaurant)
                .HasForeignKey(m => m.RestaurantId);

            // One-to-Many: User and Reservation
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reservations)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            // One-to-One: Reservation and Order
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reservation)
                .WithOne(r => r.Order)
                .HasForeignKey<Order>(o => o.ReservationId);

            // One-to-Many: Restaurant and Review
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Reviews)
                .WithOne(rv => rv.Restaurant)
                .HasForeignKey(rv => rv.RestaurantId);

            // One-to-Many: User and Review
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(rv => rv.User)
                .HasForeignKey(rv => rv.UserId);

            // One-to-Many: User and CommunityPost
            modelBuilder.Entity<User>()
                .HasMany(u => u.CommunityPosts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            // Data Seeding
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin" },
                new Role { Id = 2, Name = "Customer" }
            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Ezzeldeen", LastName = "Mohamed", Email = "john@example.com", Password = "password123" },
                new User { Id = 2, FirstName = "Adham", LastName = "Mohamed", Email = "jane@example.com", Password = "password123" }
            );

            // Seed UserRoles
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserId = 1, RoleId = 1 }, // John is Admin
                new UserRole { UserId = 2, RoleId = 2 }  // Jane is Customer
            );

            // Seed Restaurants
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant { Id = 1, Name = "Pizza Place", Description = "Best pizza in town!", Location = "123 Pizza St." },
                new Restaurant { Id = 2, Name = "Sushi Spot", Description = "Fresh sushi daily!", Location = "456 Sushi Ave." }
            );

            // Seed MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem { Id = 1, Name = "Pepperoni Pizza", Description = "Classic pizza topped with pepperoni.", Price = 9.99m, RestaurantId = 1 },
                new MenuItem { Id = 2, Name = "California Roll", Description = "Sushi roll with crab and avocado.", Price = 8.99m, RestaurantId = 2 }
            );

            // Seed Reservations
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation { Id = 1, ReservationDate = new DateTime(2024, 10, 15, 19, 30, 0), UserId = 2, RestaurantId = 1 },
                new Reservation { Id = 2, ReservationDate = new DateTime(2024, 10, 16, 20, 0, 0), UserId = 2, RestaurantId = 2 }
            );

            // Seed Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Rating = 5, Comment = "Amazing pizza!", RestaurantId = 1, UserId = 2 },
                new Review { Id = 2, Rating = 4, Comment = "Great sushi, will come back!", RestaurantId = 2, UserId = 2 }
            );

            // Seed CommunityPosts
            modelBuilder.Entity<CommunityPost>().HasData(
                new CommunityPost { Id = 1, Title = "Favorite Pizza Place", Content = "I love the Pepperoni Pizza from Pizza Place!", UserId = 2 }
            );

            // Seed Recipes
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { Id = 1, Name = "Homemade Pizza", Ingredients = "Flour, Yeast, Water, Salt, Tomato Sauce, Cheese", Instructions = "Mix ingredients, knead, bake, and enjoy!", UserId = 2 }
            );

            // Seed PaymentMethods
            modelBuilder.Entity<PaymentMethod>().HasData(
                new PaymentMethod { Id = 1, Method = "Credit Card" },
                new PaymentMethod { Id = 2, Method = "Cash" }
            );

            // Seed Notifications
            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, Message = "Welcome to the app!", UserId = 2 }
            );
        }
    }
}
