using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ItSutra.TestGame.EntityFrameworkCore
{
    public static class TestGameDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TestGameDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TestGameDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
