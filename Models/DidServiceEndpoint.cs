namespace Dgmjr.VerifiableCredentials.Models;

public class DidServiceEndpoint
{
    public Uri[] Origins { get; set; } = Empty<Uri>();
    public Uri[] Instances { get; set; } = Empty<Uri>();
}
