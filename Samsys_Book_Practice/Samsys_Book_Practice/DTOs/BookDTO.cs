using System.ComponentModel.DataAnnotations;

namespace Samsys_Book_Practice.DTOs
{
    public class BookDTO
    {
        [Required(ErrorMessage = "O identificador de livro é necessário")]
        public required int Id { get; set; }

        [Required(ErrorMessage = "O ISBN é necessário")]
        public required string Isbn { get; set; }

        [Required(ErrorMessage = "O Nome é necessário")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O Autor é necessário")]
        public required string Autor { get; set; }

        [Required(ErrorMessage = "O Preço é necessário")]
        public decimal Preco { get; set; } = decimal.Zero;
    }
}
