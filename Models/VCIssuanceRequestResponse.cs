namespace Dgmjr.VerifiableCredentials.Models;

public class VCIssuanceRequestResponse
{
    public string? RequestId { get; set; }
    public Uri Url { get; set; }

    [JProp("qrCode")]
    public Uri QRCode { get; set; }

    [JConverter(typeof(JsonIntegerToTimeSpanConverter))]
    public duration Expiry { get; set; }
}
