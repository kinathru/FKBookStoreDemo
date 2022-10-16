using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

[Table("Book", Schema = "bookstore")]
public class Book
{
    public int Id { get; set; }
    
    [ForeignKey("Author")]
    public int AuthorId { get; set; }
    public string BookName { get; set; }

    public virtual List<Chapter> Chapters { get; set; } = new();
    
    public virtual Author Author { get; set; }
}