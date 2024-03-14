using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samsys_Book_Practice.Entity
{
    public class Book
    {
        public int id {  get; set; }

        [Required(ErrorMessage = "O Isbn é necessário")]
        public required string Isbn { get; set; }

        [Required(ErrorMessage = "O Nome é necessário")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O Autor é necessário")]
        public required string Autor { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; set; } = decimal.Zero;
    }
}
