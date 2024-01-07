namespace Dgmjr.VerifiableCredentials.Models;

public class DidVerificationMethodPublicKeyJwk
{
    public string Kty { get; set; } = string.Empty;
    public string Crv { get; set; } = string.Empty;
    public string X { get; set; } = string.Empty;
    public string Y { get; set; } = string.Empty;
    public string Kid { get; set; } = string.Empty;
}
