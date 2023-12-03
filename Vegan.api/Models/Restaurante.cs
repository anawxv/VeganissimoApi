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
    //[Microsoft.EntityFrameworkCore.IndexAttribute(nameof(IdRes), IsUnique = true)]
    [PrimaryKey(nameof(IdRes))]
    [Table("restaurante")]
    public class Restaurante
    {
        public ICollection<Fornecedor>? Fornecedors { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idres")]
        [Comment("Restaurante IDRestaurante as a primary key")]
        public int IdRes;

        [ForeignKey("IdFornecedor")]
        public int IdFornecedor { get; set; }
        [NotMapped]
        public Fornecedor? Fornecedor { get; set; }

        [Required]
        [StringLength(60)]
        [Column("nomeres")]
        [NotNull]
        [Comment("Restaurante nome")]
        public string NomeRes { get; set; } = null!;

        [Column("descricaores")]
        [NotNull]
        [Comment("Descricao do restaurante")]
        public string DescricaoRes { get; set; } = null!;
        public Restaurante()
        { }

        public Restaurante(string descricaores)
        {
            DescricaoRes = descricaores;
        }
        public Restaurante(string nomeres, string descricaores)
        {
            NomeRes = nomeres;
            DescricaoRes = descricaores;
        }
        public Restaurante(int idfornecedor, string nomeres, string descricaores)
        {
            IdFornecedor = idfornecedor;
            NomeRes = nomeres;
            DescricaoRes = descricaores;
        }
        public Restaurante(int idres, int idfornecedor, string nomeres, string descricaores)
        {
            IdRes = idres;
            IdFornecedor = idfornecedor;
            NomeRes = nomeres;
            DescricaoRes = descricaores;
        }
        public RestauranteDTO ToRestaurante()
        {
            RestauranteDTO restauranteDto = new RestauranteDTOBuilder()
                    .WithIdRes(IdRes)
                    .WithIdFornecedor(IdFornecedor)
                    .WithNomeRes(NomeRes)
                    .WithDescricaoRes(DescricaoRes)
                    .Build();
            return restauranteDto;
        }
    }
}
