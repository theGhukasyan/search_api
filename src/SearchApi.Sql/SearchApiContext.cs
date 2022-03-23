using Microsoft.EntityFrameworkCore;
using SearchAPI.Domain.Contracts;
using SearchAPI.Domain.Individuals;
using SearchApi.Sql.Configurations;

namespace SearchApi.Sql
{
    public class SearchApiContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        
        public DbSet<Individual> Individuals { get; set; }

        public SearchApiContext(DbContextOptions<SearchApiContext> options) : base(options)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ContractsConfiguration().Configure(modelBuilder.Entity<Contract>());
            new IndividualsConfiguration().Configure(modelBuilder.Entity<Individual>());
        }
    }
}