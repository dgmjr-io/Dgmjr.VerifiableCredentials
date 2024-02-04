using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Microsoft.Extensions.DependencyInjection;

public class VerifiableCredentialsAutoConfigurator : IConfigureIApplicationBuilder, IConfigureIHostApplicationBuilder
{
    public ConfigurationOrder Order => ConfigurationOrder.AnyTime;

    public void Configure(IApplicationBuilder app)
    {
    }

    public void Configure(WebApplicationBuilder builder)
    {
        builder.Services.AddVerifiableCredentials(builder.Configuration);
    }
}
