using BankAccountAPI.SecondaryPort;
using BankAccountAPI.PrimaryPort.Models;
using BankAccountAPI.PrimaryPort;

namespace BankAccountAPI.SecondaryAdapter;
public class BankBalance: IBankBalance
{

    private List<BankStatement> BankStatements {get ;set;}

    public BankBalance(){
        BankStatements= new List<BankStatement>();
    }
    public  int GetBalance(){
        return 10;
    }

    public void Operation(int Amount, OperationType operationType){

        BankStatements.Add(new BankStatement{
            OperationAmount= Amount,
            OperationType= operationType,
            OperationDate= new DateTime(01/01/2022),
            Balance=  getCurrentBalance()
        });

    }
    public List<BankStatement> GetBankStatements(){

        return BankStatements;
    }

    private int getCurrentBalance(){
        var currentBalance=0;
        if(BankStatements.Count()==0){
            currentBalance=  GetBalance();
        }else{
            currentBalance= BankStatements[BankStatements.Count()-1].Balance;
        }

        return currentBalance;
    }
}
