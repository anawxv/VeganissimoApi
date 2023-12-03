using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vegan.api.Models;

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
                .HasMany(f => f.Restaurante)
                .WithOne(r => r.Fornecedor)
                .HasForeignKey(r => r.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PratoRestaurante>()
                .HasKey(pr => pr.IdPrato);

            modelBuilder.Entity<PratoRestaurante>()
                .HasOne(pr => pr.Restaurante)
                .WithMany(r => r.PratosRestaurantes)
                .HasForeignKey(pr => pr.IdRes)
                .OnDelete(DeleteBehavior.Cascade);

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
                .HasOne(r => r.Fornecedor)
                .WithMany(f => f.Restaurante)
                .HasForeignKey(r => r.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
    

        }
    
