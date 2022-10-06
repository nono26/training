using myBankAccount.SharedKernel;

namespace myBankAccount.Core.BankAccountAggregate
{
    public class BankOperation :EntityBase
    {
        public string Type{get;set;}
        public double AmountInCent {get;set;}
        public double BalanceInCentBeforeOperation{get;set;}
        public double BalanceInCentAfterOperation{get;set;}
        public bool OperationSuccess{get;set;}
        public DateTime DateOperation{get;set;}        
    }
}