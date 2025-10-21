using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FerroFogo.API.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }

        [StringLength(3000)]
        public string? Descricao { get; set; }

        public int Qtde { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorCusto { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorVenda { get; set; }

        public bool Destaque { get; set; } = false;

        [StringLength(300)]
        public string? Foto { get; set; }
    }
}
