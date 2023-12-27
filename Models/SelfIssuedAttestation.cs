namespace Dgmjr.VerifiableCredentials.Models;

public record class SelfIssuedAttestation : VCAttestationBase
{
    [JProp("inputClaim")]
    public string InputClaim { get; set; }

    [JProp("outputClaim")]
    public string OutputClaim { get; set; }

    [JProp("type")]
    public string Type { get; set; } = "SelfIssued";

    [JProp("indexed")]
    public bool IsIndexed { get; set; }
}
