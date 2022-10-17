namespace BankAccountAPI.PrimaryPort.Models
{
    public class BankStatement
    {
        public OperationType OperationType{get;set;}
        public DateTime OperationDate{get;set;}
        public int OperationAmount{get;set;}
        public int Balance{get;set;}
    }
}