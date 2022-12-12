using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace myBankAccount.Web.infrastructure
{
  internal class SwaggerGenConfigurationOptions : IConfigureOptions<SwaggerGenOptions>
  {
    private readonly IApiVersionDescriptionProvider provider;
    public SwaggerGenConfigurationOptions(IApiVersionDescriptionProvider provider)
    {
        this.provider = provider;
    }
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerDoc(
                            description.GroupName,
                            new OpenApiInfo
                            {
                                Title = "My personal api",
                                Version = description.ApiVersion.ToString()
                            });
                    }
                    
    }
  }
}