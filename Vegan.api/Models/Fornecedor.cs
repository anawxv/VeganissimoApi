using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace Vegan.api.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [PrimaryKey(nameof(IdFornecedor))]
    [Table("fornecedor")]
    public class Fornecedor
    {
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
        public int Nrdocumento {get; set;} = null;

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

    }
}
