namespace Dgmjr.VerifiableCredentials.Models;

public record class VCDisplay
{
    [JProp("card")]
    public VCCard Card { get; set; }

    [JProp("consent")]
    public VCConsent Consent { get; set; }

    [JProp("claims")]
    public VCDisplayClaim[] Claims { get; set; }

    [JProp("locale")]
    public System.Globalization.CultureInfo Locale { get; set; }

    [JProp("contract")]
    public Uri Contract { get; set; }
}
