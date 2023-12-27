namespace Dgmjr.VerifiableCredentials.Models;

public record class VCDisplayClaim
{
    [JProp("claim")]
    public string Claim { get; set; }

    [JProp("label")]
    public string Label { get; set; }

    [JProp("type")]
    public string Type { get; set; }

    [JProp("description")]
    public string Description { get; set; }
}
