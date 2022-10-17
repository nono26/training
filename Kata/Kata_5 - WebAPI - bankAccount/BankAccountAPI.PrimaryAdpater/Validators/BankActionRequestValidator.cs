using FluentValidation;
using BankAccountAPI.PrimaryAdpater.Models;
using BankAccountAPI.PrimaryPort;

namespace BankAccountAPI.PrimaryAdpater.Validators
{
    public class BankOperationRequestValidator : AbstractValidator<BankActionRequest>
    {
        public BankOperationRequestValidator(){

            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be positif");
            RuleFor(x => x.ActionType).Must(a=>
                a== OperationType.Deposit.ToString() ||
                a== OperationType.Withdraw.ToString()).
                    WithMessage("ActionType must be equal to Deposit or Withdraw");
        }
    }
}