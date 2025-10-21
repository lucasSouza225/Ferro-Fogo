using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FerroFogo.API.Models;

[Table("Produto")]
    public class Produto
{
    [Key]
    public int Id { get; set; } 

    [StringLength(100)]
    [Required(ErrorMessage = "O Nome é obrigatório")]
    public string Nome { get; set; }

    [StringLength(3000)]
    public string Descricao { get; set; }

[(3000)
    public string ValorCusto { get; set; }

     public string ValorVenda { get; set; }

    public int Qtde { get; set; } 


    [StringLength(300)]
    public string Foto { get; set; }

    
    [StringLength(26) ]
    public string Cor { get; set; }


}