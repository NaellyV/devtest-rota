using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // Adicione este using
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity; // Para IdentityRole
using RO.DevTest.Domain.Entities;

namespace RO.DevTest.Persistence
{
    public class DefaultContext : IdentityDbContext<User, IdentityRole, string> // Herda de IdentityDbContext
    {
        public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) { }

        // Mantenha seus DbSets existentes
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Importante para Identity!

            // Suas configurações personalizadas...
            modelBuilder.Entity<Sale>()
                .HasMany(s => s.SaleProducts)
                .WithOne(sp => sp.Sale) 
                .HasForeignKey(sp => sp.SaleId)
                .OnDelete(DeleteBehavior.Cascade);  

            modelBuilder.Entity<SaleProduct>()
                .HasOne(sp => sp.Product)
                .WithMany()  
                .HasForeignKey(sp => sp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurações de chave e decimal (opcional, se já definido pelo Identity)
            modelBuilder.Entity<Client>().HasKey(c => c.Id);
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Sale>().HasKey(s => s.Id);
            modelBuilder.Entity<SaleProduct>().HasKey(sp => sp.Id);

            modelBuilder.Entity<Sale>()
                .Property(s => s.TotalAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<SaleProduct>()
                .Property(sp => sp.UnitPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}