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
    //[Microsoft.EntityFrameworkCore.IndexAttribute(nameof(Email), IsUnique = true)]
    [PrimaryKey(nameof(IdFornecedor))]
    [Table("fornecedor")]
    public class Fornecedor
    {

        public ICollection<Produto>? Produtos { get; set; }
        public ICollection<Restaurante> Restaurantes { get; set;}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idfornecedor")]
        [Comment("Fornecedor IDFornecedor as a primary key")]
        public int IdFornecedor;



        [Required]
        [StringLength(60)]
        [Column("nome")]
        [NotNull]
        [Comment("Fornecedor nome")]
        public string Nome { get; set; } = null!;

        [Required]
        [Column("nrdocumento")]
        [NotNull]
        [Comment("Fornecedor nrdocumento")]
        public int Nrdocumento;
        

        [Required]
        [Column("email")]
        [StringLength(100)]
        [BindRequired]
        [EmailAddress]
        [NotNull]
        [Comment("Fornecedor email")]
        public string Email { get; set; } = null!;

        [Required]
        [Column("phone")]
        [Comment("Fornecedor phone number")]
        [StringLength(20)]
        [AllowNull]
        public string Phone { get; set; }

        /* public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        } */

        public Fornecedor()
        { }

        public Fornecedor(string nome)
        {
            Nome = nome;
        }

        public Fornecedor(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public Fornecedor(string nome, string email, string phone)
        {
            Nome = nome;
            Email = email;
            Phone = phone;
        }

        public Fornecedor(int nrdocumento, string nome, string email, string phone)
        {
            Nrdocumento = nrdocumento;
            Nome = nome;
            Email = email;
            Phone = phone;
        }


        public Fornecedor(int idfornecedor, int nrdocumento, string nome, string email, string phone)
        {
            IdFornecedor = idfornecedor;
            Nrdocumento = nrdocumento;
            Nome = nome;
            Email = email;
            Phone = phone;
        }


        public FornecedorDTO ToFornecedor()
        {
            FornecedorDTO fornecedorDto = new FornecedorDTOBuilder()
                    .WithIdFornecedor(IdFornecedor)
                    .WithNrdocumento(Nrdocumento)
                    .WithNome(Nome)
                    .WithEmail(Email)
                    .WithPhone(Phone)
                    .Build();
            return fornecedorDto;
        }

    }
}
