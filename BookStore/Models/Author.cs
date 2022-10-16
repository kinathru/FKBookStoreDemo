using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

[Table("Author", Schema = "bookstore")]
public class Author
{
    public int Id { get; set; }
    public string AuthorName { get; set; }

    public virtual List<Book> Books { get; set; } = new();
}