namespace Dgmjr.VerifiableCredentials.Models;

public class VCKeyVaultMetadata
{
    public guid SubscriptionId { get; set; }
    public string ResourceGroup { get; set; }

    [JProp("resourceName")]
    public string Name { get; set; }

    [JProp("resourceUrl")]
    public Uri Url { get; set; }
}
