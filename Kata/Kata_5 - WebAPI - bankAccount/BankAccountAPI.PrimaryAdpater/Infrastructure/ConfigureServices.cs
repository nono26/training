using BankAccountAPI.PrimaryPort;
using BankAccountAPI.Business;
using BankAccountAPI.SecondaryAdapter;
using BankAccountAPI.SecondaryPort;

namespace BankAccountAPI.PrimaryAdpater.Infrastructure
{
    internal static class ConfigureServices
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration){

            services.AddTransient<IBankOperation,BankOperation>();
            services.AddSingleton<IBankBalance, BankBalance>();
        }
        
    }
}