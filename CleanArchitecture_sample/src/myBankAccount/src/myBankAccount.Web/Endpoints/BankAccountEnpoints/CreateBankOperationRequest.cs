using System.ComponentModel.DataAnnotations;

namespace myBankAccount.Web.Endpoints.BankAccountEnpoints
{
    public class CreateBankOperationRequest
    {
        public const string Route="/BankAccounts/Operation";

        [Required]
        public int BankAccountId{get;set;}
        [Required]
        public string Type{get;set;}
        [Required]
        public double Amount{get;set;}
    }
}