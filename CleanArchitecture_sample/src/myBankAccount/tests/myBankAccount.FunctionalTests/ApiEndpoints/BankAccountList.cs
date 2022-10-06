using Ardalis.HttpClientTestExtensions;
using Xunit;
using myBankAccount.Web;
using myBankAccount.Web.Endpoints.BankAccountEnpoints;

namespace myBankAccount.FunctionalTests.ApiEndpoints
{
    [Collection("Sequential")]
    public class BankAccountList: IClassFixture<CustomWebApplicationFactory<WebMarker>>
    {
        private readonly HttpClient _client;

        public BankAccountList(CustomWebApplicationFactory<WebMarker> factory){

            _client= factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsTwoProject(){

            var result= await _client.GetAndDeserialize<BankAccountListResponse>("/BankAccounts");
        
            Assert.Equal(2, result.BankAccounts.Count());
            Assert.Contains(result.BankAccounts, i => i.Name == SeedData.myBankAccount2.Name);
        }
    }


}