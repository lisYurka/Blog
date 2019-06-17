using Blog.Logic.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Logic.Context
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            Database.Migrate();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string AdminRoleName = "Admin";
            string UserRoleName = "User";
            string AdminLogin = "admin";
            string AdminPassword = "admin";
            Role AdminRole = new Role
            {
                Id=1,
                Name = AdminRoleName 
            };
            Role UserRole = new Role
            {
                Id=2,
                Name=UserRoleName
            };
            User AdminUser = new User
            {
                Id=1,
                Mail=AdminLogin,
                Password=AdminPassword,
                RoleId=AdminRole.Id
            };
            modelBuilder.Entity<Role>().HasData(new Role[] { AdminRole, UserRole });
            modelBuilder.Entity<User>().HasData(new User[] { AdminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
