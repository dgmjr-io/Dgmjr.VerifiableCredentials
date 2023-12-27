namespace Dgmjr.VerifiableCredentials.Models;

public record class VCAttestations
{
    [JProp("idTokens")]
    public IdTokenAttestation[] IdTokens { get; set; }

    [JProp("idTokenHints")]
    public IdTokenHintAttestation[] IdTokenHints { get; set; }

    [JProp("presentations")]
    public PresentationAttestation[] Presentations { get; set; }

    [JProp("selfIssued")]
    public SelfIssuedAttestation SelfIssued { get; set; }
}
