namespace Dgmjr.VerifiableCredentials.Models
{
    public record class PresentationAttestation : VCIssuedAttestation
    {
        [JProp("credentialType")]
        public string CredentialType { get; set; }
    }
}
