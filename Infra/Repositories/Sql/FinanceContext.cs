using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Infra.Repositories.Sql
{
    public class FinanceContext : DbContext
    {
        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}