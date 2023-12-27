namespace Dgmjr.VerifiableCredentials.Models;

[JConverter(typeof(JsonDidUriConverter))]
public partial class DidUri(string uriString) : Uri(uriString)
{
    public const string DidScheme = "did";
    private const RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase;

    private const string RegexString = $"^{DidScheme}:(?<method>[a-z]+):(?<id>[a-zA-Z0-9.]+)$";
    #if !NET7_0_OR_GREATER
    private static readonly Regex _regex = new(RegexString, Options);
    private static Regex Regex() => _regex;
    #else
    [GeneratedRegex(RegexString, Options)]
    private static partial Regex Regex();
    #endif

    private string? _uriString;
    public string UriString => _uriString ??= ToString();

    public DidMethod Method =>
        Regex().Match(UriString).Groups["method"].Value switch
        {
            "ace" => DidMethod.Ace,
            "ala" => DidMethod.Ala,
            "algo" => DidMethod.Algo,
            "bba" => DidMethod.Bba,
            "btcr" => DidMethod.Btcr,
            "ccp" => DidMethod.Ccp,
            "cheqd" => DidMethod.Cheqd,
            "com" => DidMethod.Com,
            "content" => DidMethod.Content,
            "dns" => DidMethod.Dns,
            "dock" => DidMethod.Dock,
            "dyne" => DidMethod.Dyne,
            "ebsi" => DidMethod.Ebsi,
            "elem" => DidMethod.Elem,
            "emtrust" => DidMethod.Emtrust,
            "ens" => DidMethod.Ens,
            "eosio" => DidMethod.Eosio,
            "ethr" => DidMethod.Ethr,
            "ev" => DidMethod.Ev,
            "evrc" => DidMethod.Evrc,
            "evan" => DidMethod.Evan,
            "factom" => DidMethod.Factom,
            "gatc" => DidMethod.Gatc,
            "github" => DidMethod.Github,
            "hcr" => DidMethod.Hcr,
            "icon" => DidMethod.Icon,
            "iid" => DidMethod.Iid,
            "indy" => DidMethod.Indy,
            "io" => DidMethod.Io,
            "ion" => DidMethod.Ion,
            "iscc" => DidMethod.Iscc,
            "jolo" => DidMethod.Jolo,
            "jwk" => DidMethod.Jwk,
            "key" => DidMethod.Key,
            "kilt" => DidMethod.Kilt,
            "kscirc" => DidMethod.Kscirc,
            "lit" => DidMethod.Lit,
            "meta" => DidMethod.Meta,
            "moncon" => DidMethod.Moncon,
            "none" => DidMethod.None,
            "orb" => DidMethod.Orb,
            "oyd" => DidMethod.Oyd,
            "peer" => DidMethod.Peer,
            "pdc" => DidMethod.Pdc,
            "plc" => DidMethod.Plc,
            "polygonid" => DidMethod.Polygonid,
            "pkh" => DidMethod.Pkh,
            "schema" => DidMethod.Schema,
            "sol" => DidMethod.Sol,
            "sov" => DidMethod.Sov,
            "stack" => DidMethod.Stack,
            "tys" => DidMethod.Tys,
            "tz" => DidMethod.Tz,
            "unisot" => DidMethod.Unisot,
            "v1" => DidMethod.V1,
            "vaa" => DidMethod.Vaa,
            "web" => DidMethod.Web,
            _ => throw new ArgumentOutOfRangeException(nameof(Method), $"Unknown method: {Regex().Match(UriString).Groups["method"].Value}")
        };
}

public enum DidMethod
{
    Ace,
    Ala,
    Algo,
    Bba,
    Btcr,
    Ccp,
    Cheqd,
    Com,
    Content,
    Dns,
    Dock,
    Dyne,
    Ebsi,
    Elem,
    Emtrust,
    Ens,
    Eosio,
    Ethr,
    Ev,
    Evrc,
    Evan,
    Factom,
    Gatc,
    Github,
    Hcr,
    Icon,
    Iid,
    Indy,
    Io,
    Ion,
    Iscc,
    Jolo,
    Jwk,
    Key,
    Kilt,
    Kscirc,
    Lit,
    Meta,
    Moncon,
    None,
    Orb,
    Oyd,
    Peer,
    Pdc,
    Plc,
    Polygonid,
    Pkh,
    Schema,
    Sol,
    Sov,
    Stack,
    Tys,
    Tz,
    Unisot,
    V1,
    Vaa,
    Web,
}
