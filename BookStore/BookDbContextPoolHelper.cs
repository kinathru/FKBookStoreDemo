using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BookStore;

public class BookDbContextPoolHelper
{
    private static readonly PooledDbContextFactory<BookDbContext> Factory;
    private const int COL_POOL_SIZE = 100;

    static BookDbContextPoolHelper()
    {
        var options = new DbContextOptionsBuilder<BookDbContext>().UseSqlServer(Constants.BOOK_DB_CONNECTION_STRING, options => options.EnableRetryOnFailure()).Options;
        Factory = new PooledDbContextFactory<BookDbContext>(options, COL_POOL_SIZE);
    }

    public static PooledDbContextFactory<BookDbContext> GetConnectionFactory()
    {
        return Factory;
    }
}