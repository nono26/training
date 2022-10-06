using BankAccountAPI.PrimaryPort;

namespace BankAccountAPI.PrimaryAdpater.Models
{
    public class BankActionRequest{
            public int Amount{get;set;}
            public string? ActionType{get;set;}
        }
}