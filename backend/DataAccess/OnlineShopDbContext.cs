using DataAccess.Configurations;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;

namespace DataAccess
{
    public class OnlineShopDbContext(DbContextOptions options, IOptions<AuthorizationOptions> authOptions) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }

        private IDbContextTransaction? _transaction = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            modelBuilder.ApplyConfiguration(new BrandsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionsConfiguration());
            modelBuilder.ApplyConfiguration(new RolesPermissionsConfiguration(authOptions.Value));
            modelBuilder.ApplyConfiguration(new CartsConfiguration());
            modelBuilder.ApplyConfiguration(new CartProductsConfiguration());
            modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            modelBuilder.ApplyConfiguration(new OrderProductsConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public async Task BeginTranscationAsync()
        {
            if (_transaction != null) await _transaction.DisposeAsync();

            _transaction = await Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null) throw new InvalidOperationException("Transaction is not begun or is ended");

            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public async Task RollbackAsync()
        {
            if ( _transaction == null) throw new InvalidOperationException("Transaction is not begun or is ended");

            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();

            _transaction = null;
        }
    }
}
