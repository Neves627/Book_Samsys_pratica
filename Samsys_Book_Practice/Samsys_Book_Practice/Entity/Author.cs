using System.ComponentModel.DataAnnotations;

namespace Samsys_Book_Practice.Entity
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do autor é necessário")]
        public required string Nome { get; set; }
    }
}
