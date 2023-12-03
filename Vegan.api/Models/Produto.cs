using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vegan.api.DTO;
using Vegan.api.DTO.builder;
using System.Xml.Linq;


namespace Vegan.api.Models
{
    //[Microsoft.EntityFrameworkCore.IndexAttribute(nameof(IdProd), IsUnique = true)]
    [PrimaryKey(nameof(IdProd))]
    [Table("produto")]
    public class Produto
    {
        public ICollection<Fornecedor>? Fornecedors { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idprod")]
        [Comment("Produto IDProd as a primary key")]
        public int IdProd;

        [ForeignKey("IdFornecedor")]
        public int IdFornecedor { get; set; }
        
        public Fornecedor Fornecedor { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nomeprod")]
        [NotNull]
        [Comment("Produto nome")]
        public string NomeProd { get; set; } = null!;

        [Column("descricaoprod")]
        [NotNull]
        [Comment("Descricao do produto")]
        public string DescricaoProd { get; set; } = null!;

        [Column("PrecoProd")]
        [NotNull]
        [Comment("Preco do produto")]
        public int PrecoProd { get; set; }

        public Produto()
        { }

        public Produto(int precoprod)
        {
            PrecoProd = precoprod;
        }
        public Produto(string descricaoprod, int precoprod)
        {
            DescricaoProd = descricaoprod;
            PrecoProd = precoprod;
        }
        public Produto(string nomeprod, string descricaoprod, int precoprod)
        {
            NomeProd = nomeprod;
            DescricaoProd = descricaoprod;
            PrecoProd = precoprod;

        }
        public Produto(int idfornecedor, string nomeprod, string descricaoprod, int precoprod)
        {
            IdFornecedor = idfornecedor;
            NomeProd = nomeprod;
            DescricaoProd = descricaoprod;
            PrecoProd = precoprod;
        }
        public Produto(int idprod, int idfornecedor, string nomeprod, string descricaoprod, int precoprod)
        {
            IdProd = idprod;
            IdFornecedor = idfornecedor;
            NomeProd = nomeprod;
            DescricaoProd = descricaoprod;
            PrecoProd = precoprod;
        }
        public ProdutoDTO ToProduto()
        {
            ProdutoDTO produtoDto = new ProdutoDTOBuilder()
                    .WithIdProd(IdProd)
                    .WithIdFornecedor(IdFornecedor)
                    .WithNomeProd(NomeProd)
                    .WithDescricaoProd(DescricaoProd)
                    .WithPrecoProd(PrecoProd)
                    .Build();
            return produtoDto;
        }
    }
   

}
