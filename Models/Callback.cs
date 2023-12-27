namespace Dgmjr.VerifiableCredentials.Models;
using System.Runtime.Serialization;
using Json;

/// <summary>
/// Callback - defines where and how we want our callback.
/// url - points back to us
/// state - something we pass that we get back in the callback event. We use it as a correlation id
/// headers - any additional HTTP headers you want to pass to the VC Client API.
/// The values you pass will be returned, as HTTP Headers, in the callback
/// </summary>
public record class VCCallback
{
    [JProp("url")]
    public Uri Url { get; set; }

    [JProp("state")]
    public string State { get; set; }

    [JProp("headers")]
    public StringDictionary Headers { get; set; }

    [JProp("requestStatus")]
    [JIgnore(Condition = JIgnore.WhenWritingDefault)]
    public VCCallbackRequestStatus? RequestStatus { get; set; }
}

[JConverter(typeof(JsonStringEnumConverter<VCCallbackRequestStatus>))]
public enum VCCallbackRequestStatus
{
    None = 0,

    [JProp("request_retrieved")]
    [EnumMember(Value = "request_retrieved")]
    Retrieved,

    [JProp("issuance_successful")]
    [EnumMember(Value = "issuance_successful")]
    Success,

    [JProp("issuance_error")]
    [EnumMember(Value = "issuance_error")]
    Error
}

/// <summary>
/// Issuance - the specific details when you do VC issuance
/// </summary>

public record class VCIssuance
{
    [JProp("type")]
    public string Type { get; set; }

    [JProp("manifest")]
    [JsonUriString]
    public Uri Manifest { get; set; }

    [JProp("pin")]
    public VCPin Pin { get; set; }

    [JProp("claims")]
    public StringDictionary Claims { get; set; }
}

/// <summary>
/// Presentation - the specific details when you do VC presentation
/// </summary>
public record class VCPresentation
{
    [JProp("includeReceipt")]
    public bool IncludeReceipt { get; set; }

    [JProp("requestedCredentials")]
    public List<VCRequestedCredential> RequestedCredentials { get; set; }
}

/// <summary>
/// Presentation can involve asking for multiple VCs
/// </summary>
public record class VCRequestedCredential
{
    [JProp("type")]
    public string Type { get; set; }

    [JProp("manifest")]
    public Uri Manifest { get; set; }

    [JProp("acceptedIssuers")]
    public List<Uri> AcceptedIssuers { get; set; }
}

/// <summary>
/// VC Client API callback
/// </summary>
public record class VCCallbackEvent
{
    [JProp("requestId")]
    public string RequestId { get; set; }

    [JProp("requestStatus")]
    public VCCallbackRequestStatus RequestStatus { get; set; }

    [JProp("error")]
    public VCError Error { get; set; }

    [JProp("state")]
    public string State { get; set; }

    [JProp("subject")]
    public string Subject { get; set; }

    [JProp("verifiedCredentialsData")]
    public VCClaimsIssuer[] VerifiedCredentialsData { get; set; }

    [JProp("receipt")]
    public VCReceipt Receipt { get; set; }
}

/// <summary>
/// Error - in case the VC Client API returns an error
/// </summary>
public record class VCError
{
    [JProp("code")]
    public string Code { get; set; }

    [JProp("message")]
    public string Message { get; set; }

    [JProp("stackTrace")]
    public string StackTrace { get; set; }
}

/// <summary>
/// Receipt - returned when VC presentation is verified. The id_token contains the full VC id_token
/// the state is not to be confused with the VCCallbackEvent.state and is something internal to the VC Client API
/// </summary>
public record class VCReceipt
{
    [JProp("id_token")]
    public string IdToken { get; set; }

    [JProp("state")]
    public string State { get; set; }
}

/// <summary>
/// ClaimsIssuer - details of each VC that was presented (usually just one)
/// authority gives you who issued the VC and the claims is a collection of the VC's claims, like givenName, etc
/// </summary>
public record class VCClaimsIssuer
{
    [JProp("issuer")]
    public Uri Issuer { get; set; }

    [JProp("domain")]
    public string Domain { get; set; }

    [JProp("verified")]
    public string Verified { get; set; }

    [JProp("type")]
    public string[] Type { get; set; }

    [JProp("claims")]
    public IStringDictionary Claims { get; set; } = new StringDictionary();
}
