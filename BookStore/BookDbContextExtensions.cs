using System.ComponentModel;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookStore;

public static class BookDbContextExtensions
{
    public static int NextValueForSequence(this BookDbContext pCtx, Sequence pSequence)
    {
        SqlParameter result = new SqlParameter("@result", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        var sequenceIdentifier = pSequence.GetType()
            .GetMember(pSequence.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()
            ?.Description;
        pCtx.Database.ExecuteSqlRaw($"SELECT @result = (NEXT VALUE FOR [{sequenceIdentifier}]);", result);
        return (int)result.Value;
    }
}

public enum Sequence
{
    [Description("AuthorIdSeq")] AuthorIdSequence,
    [Description("BookIdSeq")] BookIdSequence
}