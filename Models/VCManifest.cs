namespace Dgmjr.VerifiableCredentials.Models;

public record class VCManifestPayload
{
    [JProp("token")]
    public string Token
    {
        get => _stringToken;
        set
        {
            _stringToken = value;
            _token = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(value);
        }
    }
    private string _stringToken;
    private System.IdentityModel.Tokens.Jwt.JwtSecurityToken _token;

    public VCManifest Manifest(Jso jso = null) =>
        _manifest ??=
            Token is null || _token is null
                ? null
                : new VCManifest
                {
                    Id = new(_token.Payload["id"]?.ToString()),
                    Display = Deserialize<VCDisplay>(
                        Serialize(_token.Payload["display"], jso),
                        jso
                    ),
                    Input = Deserialize<VCRules>(Serialize(_token.Payload["input"], jso), jso)
                };

    private VCManifest _manifest;
}

public record class VCManifest
{
    [JProp("id")]
    public guid Id { get; set; }

    [JProp("display")]
    public VCDisplay Display { get; set; }

    [JProp("input")]
    public VCRules Input { get; set; }

    [JProp("mapping")]
    public VCClaimMapping[] Mapping { get; set; }

    [JProp("configuration")]
    public Uri Configuration { get; set; }

    [JProp("trustedIssuers")]
    public Uri[] TrustedIssuers { get; set; }

    [JProp("required")]
    public bool IsRequired { get; set; }

    [JProp("clientId")]
    public string ClientId { get; set; }

    [JProp("redirectUri")]
    public Uri RedirectUri { get; set; }

    [JProp("scope")]
    public string Scope { get; set; }
}
