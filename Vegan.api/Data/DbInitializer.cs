using Vegan.api.Data;
using Vegan.api.Models;

public static class DbInitializer
{
    public static void Initialize(DataContext context)
    {

        var fornecedor = new Fornecedor
        {
            IdFornecedor = 1,
            Nome = "Jão",
            Nrdocumento = 123456789,
            Email = "jão@gmail.com",
            Phone = "123-456-7890",
            Produtos = new List<Produto>
            {
                new Produto { NomeProd = "Produto 1", PrecoProd = 10 },
                new Produto { NomeProd = "Produto 2", PrecoProd = 15 },
            },
         
        };

        
        context.Fornecedores.Add(fornecedor);
        context.SaveChanges();
    }
}
