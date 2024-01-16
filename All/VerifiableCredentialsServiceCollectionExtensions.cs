namespace Microsoft.Extensions.DependencyInjection;

public static class VerifiableCredentialsServiceCollectionExtensions
{
    public static IServiceCollection AddVerifiableCredentials(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IVerifiableCredentialsService, VerifiableCredentialsService>();
        services.Configure<VerifiableCredentialsAdminApiOptions>(config.GetSection(VerifiableCredentialsAdminApiOptions.AppSettingsKey));
        services.Configure<VerifiableCredentialsIssuerApiOptions>(config.GetSection(VerifiableCredentialsIssuerApiOptions.AppSettingsKey));
        return services;
    }
}
