using myBankAccount.Core.BankAccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace myBankAccount.Infrastructure.Data.Config
{
    public class BankOperationConfiguration:IEntityTypeConfiguration<BankOperation>
    {
        public void Configure(EntityTypeBuilder<BankOperation> builder)
        {
            builder.Property(p => p.Type)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.AmountInCent)
                .IsRequired();
        }         
    }
}