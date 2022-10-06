using Ardalis.ApiEndpoints;
using myBankAccount.Core.BankAccountAggregate;
using myBankAccount.Core.BankAccountAggregate.Specifications;
using myBankAccount.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace myBankAccount.Web.Endpoints
{
    public class GetById : EndpointBaseAsync
        .WithRequest<GetBankAccountByIdRequest>
        .WithActionResult<GetBankAccountByIdResponse>
    {

        private readonly IRepository<BankAccount> _repository;

        public GetById(IRepository<BankAccount> repository){
            _repository= repository;
        }   

        [HttpGet(GetBankAccountByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Gets a single bank account",
            Description ="Gets a single bank account by id",
            OperationId ="BankAccounts.GetById",
            Tags = new []{"BankAccountEndpoints"}
        )]

        public override async Task<ActionResult<GetBankAccountByIdResponse>> HandleAsync([FromRoute] GetBankAccountByIdRequest request,
        CancellationToken cancellationToken){

            var spec = new BankAccountByIdWithOperationsSpec(request.BankAccountId);
            var entity= await _repository.GetBySpecAsync(spec);
            if (entity == null) return NotFound();

            var response= new GetBankAccountByIdResponse
            (
                id: entity.Id,
                name: entity.Name,
                balance: entity.BalanceInCent,
                bankOperations: entity.BankOperations.Select(item => new BankOperationRecord(item.Type, item.AmountInCent,item.BalanceInCentBeforeOperation, item.BalanceInCentAfterOperation, item.OperationSuccess, item.DateOperation)).ToList()                                       
            );
           
            return Ok(response);
        }
    }
}