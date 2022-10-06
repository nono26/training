using BankAccountAPI.PrimaryPort;
using BankAccountAPI.SecondaryPort;
using BankAccountAPI.PrimaryPort.Models;

namespace BankAccountAPI.Business{
    public class BankOperation: IBankOperation
    {

        private IBankBalance _bankBalance{get;set;}

        public BankOperation(IBankBalance bankBalance){
            _bankBalance= bankBalance;
        }

        public async Task<bool> Operation(int Amount, string action){
            var success= false;

            switch(action){
                case "Deposit":
                    success= Deposit(Amount);
                    break;
                case "Withdraw":
                    success = Withdrawal(Amount);
                    break;
            }
         
            return success;
        }

        public async Task<List<BankStatement>> GetBankStatements(){
            return _bankBalance.GetBankStatements();
        }
        private bool Deposit(int Amount){
            _bankBalance.Operation(Amount, OperationType.Deposit);
            return true;
        }

        private bool Withdrawal(int Amount){
            var result= false;
            var currentBalance= _bankBalance.GetBalance();
            result= Amount <= currentBalance;
            _bankBalance.Operation(Amount,OperationType.Withdraw);
            return result;
        }

    }
}
