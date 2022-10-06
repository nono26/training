using Ardalis.ApiEndpoints;
using myBankAccount.Core.BankAccountAggregate;
using myBankAccount.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace myBankAccount.Web.Endpoints.BankAccountEnpoints
{
    public class List: EndpointBaseAsync
    .WithoutRequest
    .WithActionResult<BankAccountListResponse>
    {
        private readonly IReadRepository<BankAccount> _repository;

        public List(IReadRepository<BankAccount> repository){
            _repository= repository;
        }

        [HttpGet("/BankAccounts")]
        [SwaggerOperation(
            Summary ="Gets a list of all bank accounts",
            Description ="Gets a list of all bank accounts",
            OperationId ="bankAccounts.List",
            Tags =new []{"BankAccountEndpoints"}
        )]
        public override async Task<ActionResult<BankAccountListResponse>> HandleAsync(
            CancellationToken cancellationToken= new())
        {
            var bankAccounts= await _repository.ListAsync(cancellationToken);
            var response= new BankAccountListResponse{
                BankAccounts= bankAccounts
                    .Select(bankAccounts=> new BankAccountRecord(bankAccounts.Id, bankAccounts.Name, bankAccounts.BalanceInCent))
                    .ToList()
            };

            return Ok(response);
        }

        
    }
}