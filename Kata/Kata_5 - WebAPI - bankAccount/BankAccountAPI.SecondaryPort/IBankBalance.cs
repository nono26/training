using BankAccountAPI.PrimaryPort;
using BankAccountAPI.PrimaryPort.Models;

namespace BankAccountAPI.SecondaryPort;

public interface IBankBalance
{
    int GetBalance();
    void Operation(int Amount, OperationType operationType);
    List<BankStatement> GetBankStatements();
    
}
