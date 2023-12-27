namespace Dgmjr.VerifiableCredentials.Models;

public record class IdTokenAttestation : VCIssuedAttestation
{
    private const string VCClientOpenId = "vcclient://openid/";

    [JProp("id")]
    public Uri Id { get; set; }

    [JProp("configuration")]
    public string Configuration { get; set; }

    [JProp("type")]
    public string Type { get; set; }

    [JProp("clientId")]
    public string ClientId { get; set; }

    [JProp("redirectUri")]
    public Uri RedirectUri { get; set; } = new(VCClientOpenId);

    [JProp("scope")]
    public string Scope { get; set; }

    [JProp("encrypted")]
    public bool IsEncrypted { get; set; }
}
