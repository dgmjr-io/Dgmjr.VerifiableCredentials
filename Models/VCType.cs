namespace Dgmjr.VerifiableCredentials.Models;

public record class VCType
{
    [JProp("type")]
    public string[] Type { get; set; }
}
