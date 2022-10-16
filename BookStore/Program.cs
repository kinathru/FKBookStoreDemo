// See https://aka.ms/new-console-template for more information

using BookStore;
using BookStore.Models;
using Microsoft.Extensions.Configuration;

Console.WriteLine("Hello, World!");

var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
var config = builder.Build();
Constants.BOOK_DB_CONNECTION_STRING = config["ConnectionStrings:bookdb"];

List<Chapter> chaptersList1 = new List<Chapter>();
chaptersList1.Add(new Chapter() { ChapterName = "Chapter 1" });
chaptersList1.Add(new Chapter() { ChapterName = "Chapter 2" });
chaptersList1.Add(new Chapter() { ChapterName = "Chapter 3" });

List<Book> bookList = new List<Book>();
bookList.Add(new Book() { BookName = "Book 1", Chapters = chaptersList1 });

List<Chapter> chaptersList2 = new List<Chapter>();
chaptersList2.Add(new Chapter() { ChapterName = "Chapter 1" });
chaptersList2.Add(new Chapter() { ChapterName = "Chapter 2" });
chaptersList2.Add(new Chapter() { ChapterName = "Chapter 3" });
bookList.Add(new Book() { BookName = "Book 2", Chapters = chaptersList2 });


List<Chapter> chaptersList3 = new List<Chapter>();
chaptersList3.Add(new Chapter() { ChapterName = "Chapter 1" });
chaptersList3.Add(new Chapter() { ChapterName = "Chapter 2" });
chaptersList3.Add(new Chapter() { ChapterName = "Chapter 3" });
bookList.Add(new Book() { BookName = "Book 3", Chapters = chaptersList3 });

Author author = new Author()
{
    AuthorName = "Author 1",
    Books = bookList
};

using (var context = BookDbContextPoolHelper.GetConnectionFactory().CreateDbContext())
{
    context.Add(author);
    context.SaveChanges();
}