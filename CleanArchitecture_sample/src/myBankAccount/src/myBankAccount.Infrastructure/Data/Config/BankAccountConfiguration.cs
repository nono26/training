using myBankAccount.Core.BankAccountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace myBankAccount.Infrastructure.Data.Config
{
    public class BankAccountConfiguration :IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.Property(p => p.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.BalanceInCent)
                .IsRequired();
        }    
    }
}