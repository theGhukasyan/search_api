using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SearchAPI.Domain.Contracts;

namespace SearchApi.Sql.Configurations
{
    public class ContractsConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(_ => _.ContractCode);
            
            builder.OwnsMany(_ => _.Roles);
            builder.OwnsOne(_ => _.InstallmentAmount);
            builder.OwnsOne(_ => _.OriginalAmount);

            builder
                .HasOne(_ => _.Individual)
                .WithMany(_ => _.Contracts)
                .HasForeignKey(_ => _.CustomerCode)
                .IsRequired();

            builder.HasIndex(_ => _.CustomerCode).IsUnique(false);
        }
    }
}