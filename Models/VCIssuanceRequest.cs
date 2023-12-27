namespace Dgmjr.VerifiableCredentials.Models;

/// <summary>
/// VC Issuance
/// </summary>
public record class VCIssuanceRequest
{
    [JProp("authority")]
    public Uri Authority { get; set; }

    [JProp("includeQRCode")]
    public bool IncludeQRCode { get; set; } = true;

    [JProp("registration")]
    public VCRequestRegistration Registration { get; set; }

    [JProp("callback")]
    public VCCallback Callback { get; set; }

    [JProp("type")]
    public string Type { get; set; }

    [JProp("manifest")]
    public Uri Manifest { get; set; }

    [JProp("Pin")]
    public VCPin Pin { get; set; }

    [JProp("claims")]
    public IStringDictionary Claims { get; set; } = new StringDictionary();
}
