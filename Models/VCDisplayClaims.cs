namespace Dgmjr.VerifiableCredentials.Models;

public class VCDisplayClaims : Dictionary<string, VCDisplayClaim>
{
    public VCDisplayClaims() { }

    public VCDisplayClaims(IDictionary<string, VCDisplayClaim> dictionary) : base(dictionary) { }
}
