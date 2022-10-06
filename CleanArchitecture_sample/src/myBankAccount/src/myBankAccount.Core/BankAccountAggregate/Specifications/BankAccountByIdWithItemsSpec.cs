using Ardalis.Specification;

namespace myBankAccount.Core.BankAccountAggregate.Specifications
{
    public class BankAccountByIdWithOperationsSpec: Specification<BankAccount>, ISingleResultSpecification
    {

        public BankAccountByIdWithOperationsSpec(int BankAccountId){
            Query
                .Where(bankAccount=> bankAccount.Id== BankAccountId)
                .Include(bankAccount => bankAccount.BankOperations);
        }   
    }
}