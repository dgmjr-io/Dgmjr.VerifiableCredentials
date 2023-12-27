namespace Dgmjr.VerifiableCredentials.Models;

/// <summary>
/// Registration - used in both issuance and presentation to give the app a display name
/// </summary>
public record class Registration
{
    [JProp("clientName")]
    public string ClientName { get; set; }

    [JProp("purpose")]
    public string Purpose { get; set; }

    [JProp("logoUrl")]
    public Uri LogoUrl { get; set; }

    [JProp("termsOfServiceUrl")]
    public Uri TermsOfServiceUrl { get; set; }
}
