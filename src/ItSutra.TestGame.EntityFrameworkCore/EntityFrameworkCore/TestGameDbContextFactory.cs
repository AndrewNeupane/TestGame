using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ItSutra.TestGame.Configuration;
using ItSutra.TestGame.Web;

namespace ItSutra.TestGame.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TestGameDbContextFactory : IDesignTimeDbContextFactory<TestGameDbContext>
    {
        public TestGameDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TestGameDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TestGameDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TestGameConsts.ConnectionStringName));

            return new TestGameDbContext(builder.Options);
        }
    }
}
