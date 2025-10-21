using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FerroFogo.API.Models;

[Table("Categoria")]
    public class Categoria
{
    [Key]
    public int Id { get; set; } 

    [StringLength(30)]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    
    [StringLength(26) ]
    public string Cor { get; set; }


}