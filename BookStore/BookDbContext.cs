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
}

