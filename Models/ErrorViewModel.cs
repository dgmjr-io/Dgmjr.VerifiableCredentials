namespace Dgmjr.VerifiableCredentials.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !IsNullOrEmpty(RequestId);
}
