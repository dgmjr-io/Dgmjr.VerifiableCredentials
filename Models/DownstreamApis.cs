namespace Dgmjr.VerifiableCredentials.Models;

public interface IDownstreamApis
{
    VerifiableCredentialsAdminApiOptions VerifiableCredentialsOptions { get; set; }
    VerifiableCredentialsAdminApiOptions VerifiableCredentialsIssuer { get; set; }
}

public record class DownstreamApis : Dgmjr.Web.DownstreamApis.DownstreamApis, IDownstreamApis
{
    [JProp(nameof(Models.VerifiableCredentialsAdminApiOptions))]
    VerifiableCredentialsAdminApiOptions IDownstreamApis.VerifiableCredentialsOptions { get; set; }

    [JProp(nameof(IDownstreamApis.VerifiableCredentialsIssuer))]
    VerifiableCredentialsAdminApiOptions IDownstreamApis.VerifiableCredentialsIssuer { get; set; }
}
