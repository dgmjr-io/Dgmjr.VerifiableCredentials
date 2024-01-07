namespace Dgmjr.VerifiableCredentials.Models;

public class DidVerificationMethod
{
    public Uri Id { get; set; }

    public Uri Controller { get; set; }

    public string Type { get; set; } = string.Empty;

    public DidVerificationMethodPublicKeyJwk PublicKeyJwk { get; set; } = new();
}
