using myBankAccount.SharedKernel;
using myBankAccount.SharedKernel.Interfaces;

namespace myBankAccount.Core.BankAccountAggregate
{
    public class BankAccount : EntityBase, IAggregateRoot
    {
        public string Name{get;private set;}
        public double BalanceInCent{get;private set;}

        private List<BankOperation> bankOperations=new List<BankOperation>();
        public IEnumerable<BankOperation> BankOperations => bankOperations.AsReadOnly();

        public BankAccount(string name, double balanceInCent){
            Name= name;
            BalanceInCent= balanceInCent;
        }

        public bool Operation(BankOperation myBankOperation){
            myBankOperation.BalanceInCentBeforeOperation= BalanceInCent;            
            myBankOperation.OperationSuccess=ExecuteOperation(myBankOperation.Type, myBankOperation.AmountInCent);
            myBankOperation.BalanceInCentAfterOperation= BalanceInCent;
            bankOperations.Add(myBankOperation);
            return myBankOperation.OperationSuccess;
        }

        private bool ExecuteOperation(string Type, double AmountInCent ){
            var returnValue= false;
            switch(Type){
                case "Deposit":
                    returnValue=Deposit(AmountInCent);
                    break;
                case "Withdrawal":
                    returnValue=Withdrawal(AmountInCent);
                    break;
            }
            return returnValue;
        }
        private bool Deposit(double AmountInCent){
            var result= false;
            if(AmountInCent>0){
                BalanceInCent += AmountInCent;
                result=true;
            }
            return result;
        }

        private bool Withdrawal(double AmountInCent){
            var result =false;
            if(AmountInCent <BalanceInCent)
            {
                BalanceInCent-= AmountInCent;
                result= true;
            }
            return result;
        }
    }
}