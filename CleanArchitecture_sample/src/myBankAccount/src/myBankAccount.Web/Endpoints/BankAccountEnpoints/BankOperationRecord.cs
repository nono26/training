namespace myBankAccount.Web.Endpoints
{   
    public record BankOperationRecord(
        string  Type,
        double Amount,
        double BalanceBeforeOperation,
        double BalanceAfterOperation,
        bool OperationSuccess,
        DateTime DateOperation
     );    
}