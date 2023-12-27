using System;
using System.Linq;

namespace Dgmjr.VerifiableCredentials.Models;

using Microsoft.Identity.Abstractions;
using Dgmjr.VerifiableCredentials.Json;

public class VerifiableCredentialsAdminApiOptions : DownstreamApiOptions
{
    public const string AppSettingsKey = nameof(VerifiableCredentialsAdminApiOptions);

    public const string DefaultApiEndpointString =
        "https://verifiedid.did.msidentity.com/v1.0/verifiableCredentials/{0}";

    public const string DefaultApiKey = "INMEM-API-KEY";

    public const string DefaultClientName = "DGMJR Verifiable Credentials Issuer";

    public string AuthorityId { get; set; }
}
public class VerifiableCredentialsIssuerApiOptions : DownstreamApiOptions
{
    public const string AppSettingsKey = nameof(VerifiableCredentialsIssuerApiOptions);

    public const string DefaultApiEndpointString =
        "https://verifiedid.did.msidentity.com/v1.0/verifiableCredentials/{0}";

    public const string DefaultApiKey = "INMEM-API-KEY";

    public const string DefaultClientName = "DGMJR Verifiable Credentials Issuer";

    [JsonUriString]
    public Uri VerifierAuthority { get; init; }

    [JsonUriString]
    public Uri IssuerAuthority { get; init; }

    [JsonApiEndpointUriString]
    public ApiEndpointUri Urls { get; init; } = new(DefaultApiEndpointString);
    public string ApiKey { get; init; } = guid.NewGuid().ToString();
    public string ClientName { get; init; } = DefaultClientName;
    public string AuthorityId { get; set; }
    public byte PinLength { get; init; }
}
