namespace myBankAccount.Web.Endpoints
{
    public class GetBankAccountByIdResponse
    {
        public GetBankAccountByIdResponse(int id, string name, double balance, List<BankOperationRecord> bankOperations){
            Id= id;
            Name= name;
            Balance= balance;
            BankOperations= bankOperations;
        }
        public int Id{get;set;}
        public string? Name{get;set;}
        public double Balance{get;set;}
        public List<BankOperationRecord> BankOperations{get;set;}= new ();
    }
}