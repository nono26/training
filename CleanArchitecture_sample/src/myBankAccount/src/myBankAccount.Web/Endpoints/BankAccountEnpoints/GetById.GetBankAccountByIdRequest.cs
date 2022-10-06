namespace myBankAccount.Web.Endpoints
{
    public class GetBankAccountByIdRequest
    {
        public const string Route="/BankAccounts/{BankAccountId:int}";
        public static string BuildRoute(int bankAccountId)=> Route.Replace("{BankAccountId:int}",bankAccountId.ToString());
        public int BankAccountId{get;set;}
    }
}