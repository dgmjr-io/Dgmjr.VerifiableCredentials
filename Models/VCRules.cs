namespace Dgmjr.VerifiableCredentials.Models;

public record class VCRules
{
    [JProp("attestations")]
    public VCAttestations Attestations { get; set; }

    [JProp("credentialIssuer")]
    public Uri CredentialIssuer { get; set; }

    [JProp("issuer")]
    public Uri Issuer { get; set; }

    [JProp("customStatusEndpoint")]
    public Uri CustomStatusEndpoint { get; set; }

    [JProp("vc")]
    // [JIgnore]
    public VCType VC { get; set; }
}
