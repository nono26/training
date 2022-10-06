using Ardalis.ApiEndpoints;
using myBankAccount.Core.BankAccountAggregate;
using myBankAccount.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using myBankAccount.Core.BankAccountAggregate.Specifications;

namespace myBankAccount.Web.Endpoints.BankAccountEnpoints
{
    public class Create : EndpointBaseAsync
        .WithRequest<CreateBankOperationRequest>
        .WithActionResult<bool>
    {
        private readonly IRepository<BankAccount> _repository;

        public Create(IRepository<BankAccount> repository){
            _repository= repository;
        }

        [HttpPost("/BankAccounts/Operation")]
        [SwaggerOperation(
            Summary ="Creates a bank operation for a bank account",
            OperationId= "BankAccount.Create",
            Tags = new[] {"BankAccountEndpoints"})
        ]
        public override async Task<ActionResult<bool>> HandleAsync(CreateBankOperationRequest request, CancellationToken cancellationToken){
            
            if(request.BankAccountId==0){
                return BadRequest();
            }
            var spec = new BankAccountByIdWithOperationsSpec(request.BankAccountId);
            var entity= await _repository.GetBySpecAsync(spec);
            if (entity == null) return NotFound();

            var result= entity.Operation(new BankOperation{Type= request.Type, AmountInCent= request.Amount, DateOperation= DateTime.Now });

            await _repository.UpdateAsync(entity);
            
            return Ok(result);
        }
    }
}