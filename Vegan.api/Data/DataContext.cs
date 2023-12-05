using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vegan.api.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;


namespace Vegan.api.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Fornecedor> Fornecedors { get; set;}           
        public DbSet<Produto> Produtos { get; set;}  
        public DbSet<Restaurante> Restaurantes { get; set;}
        public DbSet<PratoRestaurante> PratoRestaurantes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>()
                .HasKey(f => f.IdFornecedor);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(f => f.Restaurants)
                .WithMany(r => r.Fornecedors)
                .UsingEntity(j => j.ToTable("RestauranteFornecedor"));

            modelBuilder.Entity<Produto>()
                .HasKey(p => p.IdProd);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Fornecedor)
                .WithMany(f => f.Produtos)
                .HasForeignKey(p => p.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Restaurante>()
                .HasKey(r => r.IdRes);

            modelBuilder.Entity<Restaurante>()
                .HasMany(r => r.PratoRestaurantes)
                .WithMany(pr => pr.Restaurantes)
                .UsingEntity(j => j.ToTable("PratosRestaurantes"));

            modelBuilder.Entity<PratoRestaurante>()
                .HasKey(pr => pr.IdPrato);

            base.OnModelCreating(modelBuilder);
        }
    }
}
    

        
    
