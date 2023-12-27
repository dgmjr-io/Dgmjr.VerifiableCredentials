namespace Dgmjr.VerifiableCredentials.Models;

public abstract record class VCAttestationBase
{
    [JProp("mapping")]
    public VCClaimMapping[] Mapping { get; set; }

    [JProp("required")]
    public bool IsRequired { get; set; }
}

public abstract record class VCIssuedAttestation : VCAttestationBase
{
    [JProp("trustedIssuers")]
    public Uri[] TrustedIssuers { get; set; }
}
