using myBankAccount.Core.BankAccountAggregate;
using myBankAccount.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace myBankAccount.Web;

public static class SeedData
{ 
  //BankAccount data

  public static readonly BankAccount myBankAccount1= new BankAccount("Martin",0);

  public static readonly BankAccount myBankAccount2= new BankAccount("Cathal",10000);

  public static readonly IEnumerable<BankOperation> myBankOperations= new List<BankOperation>();

  public static readonly BankOperation myOp1= new BankOperation{
    Type="Deposit",
    AmountInCent=2000,
    DateOperation= DateTime.Now.AddDays(-1)
  };
  public static readonly BankOperation myOp2= new BankOperation{
    Type="Withdrawal",
    AmountInCent=100,
    DateOperation= DateTime.Now
  };

  public static readonly BankOperation myOp3= new BankOperation{
    Type="Deposit",
    AmountInCent=4000,
    DateOperation= DateTime.Now.AddDays(-2)
  };
  public static readonly BankOperation myOp4= new BankOperation{
    Type="Withdrawal",
    AmountInCent=200,
    DateOperation= DateTime.Now
  };


  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var dbContext = new AppDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
    {
      PopulateTestData(dbContext);
    }
  }
  public static void PopulateTestData(AppDbContext dbContext)
  {  
    myBankAccount1.Operation(myOp1);
    myBankAccount1.Operation(myOp2);

    myBankAccount2.Operation(myOp3);
    myBankAccount2.Operation(myOp4);


    dbContext.BankAccounts.Add(myBankAccount1);
    dbContext.BankAccounts.Add(myBankAccount2);
    dbContext.SaveChanges();
  }  
}
