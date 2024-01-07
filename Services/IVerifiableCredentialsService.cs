namespace Dgmjr.VerifiableCredentials.Services;

using Microsoft.Maui.Graphics;
using Models;

public interface IVerifiableCredentialsService : ILog
{
    Task<(
        string Name,
        string Instructions,
        guid AuthorityId,
        string Id,
        VCLogo Logo
    )[]> GetVCsAsync();
    Task<VCLogo> GetCredentialIconAsync(string? credentialId);
    Task<VCContract[]> GetVCContractsAsync();
    Task<VCAuthority[]> GetAuthoritiesAsync();
    Task<IImage> GetResizedCredentialIconAsync(string? credentialId, int maxDimension);
    Task<byte[]> GetResizedCredentialIconBytesAsync(string? credentialId, int maxDimension);
    Task<VCIssuanceRequestResponse> SendIssuanceRequestAsync(VCIssuanceRequest request);
    VCIssuanceRequest CreateIssuanceRequest(guid contractId, Uri callbackUrl, string stateId, CustomClaimMapper customClaimMapper);
    VerifiableCredentialsIssuerApiOptions IssuerOptions { get; }
    Task<VCAuthority> CreateAuthorityAsync(VCAuthorityCreateDto createDto);
    Task<WellKnownDidConfiguration> GenerateWellKnownDidConfiguration(guid authorityId, UriOrString domainUrl);
    Task<DidDocument> GenerateDidDocument(guid authorityId, UriOrString domainUrl);
}
