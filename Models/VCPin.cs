namespace Dgmjr.VerifiableCredentials.Models;

/// <summary>
/// Pin - if issuance involves the use of a pin code. The 'value' attribute is a string so you can have values like "0907"
/// </summary>
public record class VCPin
{
    [JProp("value")]
    public string Value { get; set; }

    [JProp("length")]
    public int Length { get; set; }

    [JProp("type")]
    public PinType Type { get; set; } = PinType.Numeric;

    [JProp("alg")]
    public PinAlgorithm Algorithm { get; set; } = PinAlgorithm.Sha256;

    [JProp("iterations")]
    public byte Iterations { get; set; } = 3;

    [JProp("salt")]
    public string Salt { get; set; } = string.Empty;
}

[JConverter(typeof(JsonStringEnumConverter<PinType>))]
public enum PinType
{
    None,
    Numeric,
    Alphanumeric
}

[JConverter(typeof(JsonStringEnumConverter<PinAlgorithm>))]
public enum PinAlgorithm
{
    None,
    Sha256,
    Sha512
}
