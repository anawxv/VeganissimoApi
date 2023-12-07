using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vegan.api.Models;



namespace Vegan.api.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Fornecedor> Fornecedores { get; set;}           
        public DbSet<Produto> Produtos { get; set;}  
        public DbSet<Restaurante> Restaurantes { get; set;}
        public DbSet<PratoRestaurante> PratoRestaurantes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Fornecedor>()
                .HasKey(f => f.IdFornecedor);

            modelBuilder.Entity<Fornecedor>().HasData(
            new Fornecedor
            {
                IdFornecedor = 1,
                Nome = "Jão João",
                Nrdocumento = 446655532,
                Email = "jaojoao@gmail.com",
                Phone = "40028922",
                
            });

             modelBuilder.Entity<Produto>().HasData(
                        new Produto
                        {
                            IdProd = 1,
                            IdFornecedor = 1,
                            NomeProd = "Shampoo de menta vegano",
                            DescricaoProd = "Shampoo com ingredientes naturais. Cruelty-free e vegano",
                            PrecoProd = 25
                        });

            modelBuilder.Entity<Restaurante>().HasData(
                new Restaurante
                {
                    IdRes = 1,
                    IdFornecedor = 1,
                    NomeRes = "Brown kitchen",
                    DescricaoRes = "Um dos melhores restaurantes veganos de sp. Localizado na Vila Madalena, Rua papap, n° tal",

                }
                );
            modelBuilder.Entity<PratoRestaurante>().HasData(
                new PratoRestaurante
                {
                    IdPrato = 1, 
                    IdRes = 1,
                    NomePrato = "Lasanha de abobrinha vegana",
                    DescricaoPrato = "Lasanha vegana de aabobrinha, cogumelos e espinafre",
                    PrecoPrato = 32
                }
                );

            modelBuilder.Entity<Fornecedor>()
                .HasMany(f => f.Produtos)
                .WithOne(p => p.Fornecedor)
                .HasForeignKey(p => p.IdFornecedor)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Fornecedor>()
                .HasMany(f => f.Restaurantes)
                .WithMany(r => r.Fornecedores)
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
                .HasMany(r => r.PratosRestaurantes)
                .WithMany(pr => pr.Restaurantes)
                .UsingEntity(j => j.ToTable("PratosRestaurantes"));

            modelBuilder.Entity<PratoRestaurante>()
                .HasKey(pr => pr.IdPrato);

            base.OnModelCreating(modelBuilder);
        }
    }
}
    

        
    
