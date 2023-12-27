namespace Dgmjr.VerifiableCredentials.Models;

public record class VCConsent
{
    [JProp("title")]
    public string Title { get; set; }

    [JProp("instructions")]
    public string Instructions { get; set; }
}
