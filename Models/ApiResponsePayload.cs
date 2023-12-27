namespace Dgmjr.VerifiableCredentials.Models;

public record class ApiResponsePayload<TValue>
{
    public TValue Value { get; set; }
}
