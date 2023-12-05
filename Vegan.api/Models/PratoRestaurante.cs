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

    //[Microsoft.EntityFrameworkCore.IndexAttribute(nameof(IdPrato), IsUnique = true)]
    [PrimaryKey(nameof(IdPrato))]
    [Table("pratorestaurante")]
    public class PratoRestaurante
    {
        public ICollection<Restaurante> Restaurantes { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idprato")]
        [Comment("Prato IDPrato as a primary key")]
        public int IdPrato;

        [ForeignKey("IdRes")]
        public int IdRes { get; set; }
        [NotMapped]
        public Restaurante Restaurante { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nomeprato")]
        [NotNull]
        [Comment("Prato nome")]
        public string NomePrato { get; set; } = null!;

        [Column("descricaoprato")]
        [NotNull]
        [Comment("Descricao do prato")]
        public string DescricaoPrato { get; set; } = null!;

        [Column("PrecoPrato")]
        [NotNull]
        [Comment("Preco do prato")]
        public int PrecoPrato { get; set; }


        public PratoRestaurante()
        { }

        public PratoRestaurante(int precoprato)
        {
            PrecoPrato = precoprato;
        }

        public PratoRestaurante(string descricaoprato, int precoprato)
        {
            DescricaoPrato = descricaoprato;
            PrecoPrato = precoprato;
        }
        public PratoRestaurante(string nomeprato, string descricaoprato, int precoprato)
        {
            NomePrato = nomeprato;
            DescricaoPrato = descricaoprato;
            PrecoPrato = precoprato;
        }
        public PratoRestaurante(int idres, string nomeprato, string descricaoprato, int precoprato)
        {
            IdRes = idres;
            NomePrato = nomeprato;
            DescricaoPrato = descricaoprato;
            PrecoPrato = precoprato;
        }
        public PratoRestaurante(int idprato, int idres, string nomeprato, string descricaoprato, int precoprato)
        {
            IdPrato = idprato;
            IdRes = idres;
            NomePrato = nomeprato;
            DescricaoPrato = descricaoprato;
            PrecoPrato = precoprato;
        }

        public PratoRestauranteDTO ToPratoRestaurante()
        {
            PratoRestauranteDTO pratorestauranteDto = new PratoRestauranteDTOBuilder()
                    .WithIdPrato(IdPrato)
                    .WithIdRes(IdRes)
                    .WithNomePrato(NomePrato)
                    .WithDescricaoPrato(DescricaoPrato)
                    .WithPrecoPrato(PrecoPrato)
                    .Build();
            return pratorestauranteDto;
        }
    }
}
