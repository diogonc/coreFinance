using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace CoreFinance
{
    public class FinanceContextFactory : IDesignTimeDbContextFactory<FinanceContext>
    {
        public FinanceContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinanceContext>();
            optionsBuilder.UseSqlite("Data Source=finance.db", b => b.MigrationsAssembly("MigrationTools"));

            return new FinanceContext(optionsBuilder.Options);
        }
    }
}

// comandos para migrar
// dotnet ef migrations add InitialMigration -s ../CoreFinance/
// dotnet ef database update -s ../CoreFinance/
// -s stands for startup project and ../CoreFinance/ is the location of my web/startup project.