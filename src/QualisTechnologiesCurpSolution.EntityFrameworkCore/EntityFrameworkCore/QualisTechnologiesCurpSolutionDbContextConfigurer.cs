using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace QualisTechnologiesCurpSolution.EntityFrameworkCore
{
    public static class QualisTechnologiesCurpSolutionDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<QualisTechnologiesCurpSolutionDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<QualisTechnologiesCurpSolutionDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
