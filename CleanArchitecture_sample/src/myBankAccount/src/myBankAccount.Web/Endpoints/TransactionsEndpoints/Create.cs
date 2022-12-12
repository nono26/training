using Ardalis.ApiEndpoints;
using myBankAccount.Core.BankAccountAggregate;
using myBankAccount.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using myBankAccount.Core.BankAccountAggregate.Specifications;

namespace myBankAccount.Web.Endpoints.TransactionsEnpoints
{
    public class Create : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<bool>
    {

        [HttpPost("/Transaction/Operation")]
        [SwaggerOperation(
            Summary ="Creates a bank operation for a bank account",
            OperationId= "Transaction.Create",
            Tags = new[] {"TransactionEndpoints"})
        ]
        public override async Task<ActionResult<bool>> HandleAsync(CancellationToken cancellationToken){
            
            return Ok(true);
        }
    }
}