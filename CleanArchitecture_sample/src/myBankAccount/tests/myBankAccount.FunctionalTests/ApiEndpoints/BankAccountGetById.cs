using Ardalis.HttpClientTestExtensions;
using myBankAccount.Web;
using myBankAccount.Web.Endpoints;
using Xunit;

namespace myBankAccount.FunctionalTests.ApiEndpoints
{
    [Collection("Sequential")]
    public class BankAccountGetById: IClassFixture<CustomWebApplicationFactory<WebMarker>>
    {
        private readonly HttpClient _client;

        public BankAccountGetById(CustomWebApplicationFactory<WebMarker> factory){
            _client= factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsSeedProjectGivenId1(){
            var result= await _client.GetAndDeserialize<GetBankAccountByIdResponse>(GetBankAccountByIdRequest.BuildRoute(1));

            Assert.Equal(1,result.Id);
            Assert.Equal(SeedData.myBankAccount1.Name, result.Name);
            Assert.Equal(2, result.BankOperations.Count);
        }

        [Fact]
        public async Task ReturnsNotFoundGivenId0(){
            string route= GetBankAccountByIdRequest.BuildRoute(0);
            _= await _client.GetAndEnsureNotFound(route);
        }
    }
}