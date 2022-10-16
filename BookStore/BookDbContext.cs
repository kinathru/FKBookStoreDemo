using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore;

public class BookDbContext : DbContext
{
    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Chapter> Chapters { get; set; }

    public BookDbContext(DbContextOptions options) : base(options)
    {
    }
    
    private void BeforeSavingChanges()
    {
        var newAuthors = base.ChangeTracker.Entries().Where(x => x.Entity is Author && x.State == EntityState.Added).ToList();
        foreach (var entry in newAuthors)
        {
            var newAuthor = (Author)entry.Entity;
            newAuthor.Id = this.NextValueForSequence(Sequence.AuthorIdSequence);
            foreach (var newBook in newAuthor.Books)
            {
                newBook.Id = this.NextValueForSequence(Sequence.BookIdSequence);
                newBook.AuthorId = newAuthor.Id;

                foreach (var chapter in newBook.Chapters)
                {
                    chapter.AuthorId = newAuthor.Id;
                    chapter.BookId = newBook.Id;
                }
            }
        }
    }

    public override int SaveChanges()
    {
        BeforeSavingChanges();
        return base.SaveChanges();
    }
}

