using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAPI.Domain.Individuals;

namespace SearchApi.Sql.Configurations
{
    public class IndividualsConfiguration : IEntityTypeConfiguration<Individual>
    {
        public void Configure(EntityTypeBuilder<Individual> builder)
        {
            builder.HasKey(_ => _.NationalId);

            builder.HasIndex(_ => _.NationalId).IsUnique();
            builder.HasIndex(_ => _.FirstName);
            builder.HasIndex(_ => _.LastName);
            builder.HasIndex(_ => _.DateOfBirth);
        }
    }
}