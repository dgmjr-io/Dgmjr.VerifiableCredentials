namespace Dgmjr.VerifiableCredentials.Models;

public record class VCRequestRegistration
{
    [JProp("clientName")]
    public string ClientName { get; init; }

    [JProp("purpose")]
    public string Purpose { get; init; }

    [JProp("logoUrl")]
    public Uri LogoUrl { get; init; }

    [JProp("termsOfServiceUrl")]
    public Uri TermsOfServiceUrl { get; init; }
}
