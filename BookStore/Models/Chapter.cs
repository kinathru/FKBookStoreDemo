using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models;

[Table("Chapter", Schema = "bookstore")]
public class Chapter
{
    public int Id { get; set; }
    
    [ForeignKey("Book")]
    public int BookId { get; set; }
    
    [ForeignKey("Author")]
    public int AuthorId { get; set; }
    public string ChapterName { get; set; }
    
    public virtual Book Book { get; set; }
}