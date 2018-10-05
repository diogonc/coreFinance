using Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CoreFinance
{
    public class FinanceContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public FinanceContext(DbContextOptions<FinanceContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(user => user.Uuid);
        }
    }
}