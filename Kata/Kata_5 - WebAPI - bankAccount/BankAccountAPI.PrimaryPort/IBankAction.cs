using BankAccountAPI.PrimaryPort.Models;
namespace BankAccountAPI.PrimaryPort;

public interface IBankOperation
{
    Task<bool> Operation(int Amount, string action);
    Task<List<BankStatement>> GetBankStatements();
}

public enum OperationType{
    Deposit,
    Withdraw
}
