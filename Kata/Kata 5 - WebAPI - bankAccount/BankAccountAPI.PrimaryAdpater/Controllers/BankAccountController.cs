using BankAccountAPI.PrimaryPort;
using Microsoft.AspNetCore.Mvc;
using BankAccountAPI.PrimaryAdpater.Models;
using BankAccountAPI.PrimaryAdpater.Validators;

namespace BankAccountAPI.PrimaryAdpater.Controllers
{
    [Route("BankAccount")]
    [ApiController]
    public class BankAccountController: ApiControllerBase
    {
        private IBankOperation _service;

        public BankAccountController(IBankOperation bankAction){
            _service= bankAction;
        }

        [HttpPost]
        [Route("operation")]
        public async Task<ActionResult<bool>> ProcessBankAction([FromBody] BankActionRequest request){
        
            if(ValidateBankOperationRequest(request)){
                return await ExecutePost(() => _service.Operation(request.Amount, request.ActionType), 
                    $"Error processing bank action: {request.ActionType.ToString()}, amount: {request.Amount}.");
            }
            else{
                return false;
            }
        }

        private bool ValidateBankOperationRequest(BankActionRequest request)
        {
            var validator = new BankOperationRequestValidator().Validate(request);
            return validator.IsValid ? validator.IsValid : throw new ArgumentException(validator.ToString(", "));
        }


    }
}