namespace Dgmjr.VerifiableCredentials.Models;
using Json;

[JsonApiEndpointUriString]
public class ApiEndpointUri(string uriString)  : UriOrString(uriString)
{
    public override string ToString()
    {
        return base.ToString().TrimEnd('/');
    }

    [JIgnore]
    public const string CreateIssuanceRequestConstant = "createIssuanceRequest";

    [JIgnore]
    public string CreateIssuanceRequest => CreateIssuanceRequestConstant;
    [JIgnore]
    public const string CreatePresentationRequestConstant = "createPresentationRequest";
    [JIgnore]
    public string CreatePresentationRequest => CreatePresentationRequestConstant;
    [JIgnore]
    public NetworkApiEndpoint NetworkEndpoint => new(Format(ToString(), "verifiableCredentialsNetwork/{0}"));
    [JIgnore]
    public ContractsApiEndpoint ContractsEndpoint => new(Format(ToString(), "verifiableCredentialsNetwork/{0}"));

    public string Authorities => "authorities";
    public string GenerateDidDocument(guid authorityId) => $"authorities/{authorityId}/generateDidDocument";
    public string GenerateWellknownDidConfiguration(guid authorityId) => $"authorities/{authorityId}/generateWellknownDidConfiguration";
    public string Authority(guid authorityId) => $"authorities/{authorityId}";
    public string Contracts(guid authorityId) => $"authorities/{authorityId}/contracts";
    public string Contract(guid authorityId, string contractId) => $"authorities/{authorityId}/contracts/{contractId}";

    // public Uri ContractsByAuthorityIdAndContractId(guid authorityId, string contractId) => new(Format(Format(ToString(), $"verifiableCredentials/authorities/{0}/contracts/{1}"), authorityId, contractId));
}

public class NetworkApiEndpoint(string uriString) : UriOrString(uriString)
{
    public Uri Authorities(string linkedDomain) =>
        !IsNullOrEmpty(linkedDomain) ?
        new(Format(ToString(), $"authorities?filter=linkeddomainurls+like+{linkedDomain}")) :
        new(Format(ToString(), "authorities"));
}


public class ContractsApiEndpoint(string uriString) : UriOrString(uriString)
{
    public Uri Authorities(string linkedDomain) =>
        !IsNullOrEmpty(linkedDomain) ?
        new(Format(ToString(), $"authorities?filter=linkeddomainurls+like+{linkedDomain}")) :
        new(Format(ToString(), "authorities"));
}

