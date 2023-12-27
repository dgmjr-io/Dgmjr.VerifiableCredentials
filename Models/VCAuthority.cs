namespace Dgmjr.VerifiableCredentials.Models;

public record class VCAuthority
{
    public guid Id { get; set; }
    public string Name { get; set; }
    public guid TenantId { get; set; }
    public DidUri Did { get; set; }
    public DidModel DidModel { get; set; }
    public Uri[] LinkedDomainUrls { get; set; }
}

public record struct VCAuthorityCreateDto
{
    public string Name { get; set; }
    public Uri LinkedDomainUrl { get; set; }
    public DidMethod DidMethod { get; set; }
    public VCKeyVaultMetadata KeyVaultMetadata { get; set; }
}

public record class VCAuthorities
{
    public VCAuthority[] Value { get; set; }
}
