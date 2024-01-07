namespace Dgmjr.VerifiableCredentials.Models;

public class DidService
{
    public Uri Id { get; set; }

    public string Type { get; set; } = string.Empty;

    public DidServiceEndpoint ServiceEndpoint { get; set; } = new();
}
