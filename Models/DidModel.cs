namespace Dgmjr.VerifiableCredentials.Models;

public class DidModel
{
    public DidUri Did { get; set; }
    public string Name { get; set; }
    public DidDocumentStatus DidDocumentStatus { get; set; }
    public string[] SigningKeys { get; set; }
    public string[] RecoveryKeys { get; set; }
    public string[] UpdateKeys { get; set; }
    public string[] EncryptionKeys { get; set; }

    [JProp("didModel")]
    public DidModel Model { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter<DidDocumentStatus>))]
public enum DidDocumentStatus
{
    Published,
    Submitted,
    OutOfSync
}
