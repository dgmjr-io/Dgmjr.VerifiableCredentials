namespace Dgmjr.VerifiableCredentials.Models;

public class DidDocument
{
    public Uri Id { get; set; }

    [JProp("@context")]
    public LdContext[] Context { get; set; } = Empty<LdContext>();

    [JProp("service")]
    public DidService[] Services { get; set; } = Empty<DidService>();

    [JProp("verificationMethod")]
    public DidVerificationMethod[] VerificationMethod { get; set; } = Empty<DidVerificationMethod>();

    public Uri[] Authentication { get; set; } = Empty<Uri>();

    public Uri[] AssertionMethod { get; set; } = Empty<Uri>();

    public Uri[] KeyAgreement { get; set; } = Empty<Uri>();

    public Uri[] CapabilityInvocation { get; set; } = Empty<Uri>();

    public Uri[] CapabilityDelegation { get; set; } = Empty<Uri>();

    public Uri[] DelegationMethod { get; set; } = Empty<Uri>();

    public Uri[] InvocationService { get; set; } = Empty<Uri>();

    public Uri[] ServiceEndpoint { get; set; } = Empty<Uri>();

    public Uri[] Verification { get; set; } = Empty<Uri>();

    public Uri[] Recovery { get; set; } = Empty<Uri>();

    public Uri[] Update { get; set; } = Empty<Uri>();

    /*
    {
    "id": "did:web:verifiedid.contoso.com",
    "@context": [
        "https://www.w3.org/ns/did/v1",
        {
            "@base": "did:web:verifiedid.contoso.com"
        }
    ],
    "service": [
        {
            "id": "#linkeddomains",
            "type": "LinkedDomains",
            "serviceEndpoint": {
                "origins": [
                    "https://verifiedid.contoso.com/"
                ]
            }
        },
        {
            "id": "#hub",
            "type": "IdentityHub",
            "serviceEndpoint": {
                "instances": [
                    "https://verifiedid.hub.msidentity.com/v1.0/f640a374-b380-42c9-8e14-d174506838e9"
                ]
            }
        }
    ],
    "verificationMethod": [
        {
            "id": "#a2518db3b6b44332b3b667928a51b0cavcSigningKey-f0a5b",
            "controller": "did:web:verifiedid.contoso.com",
            "type": "EcdsaSecp256k1VerificationKey2019",
            "publicKeyJwk": {
                "crv": "secp256k1",
                "kty": "EC",
                "x": "bFkOsjDB_K-hfz-c-ggspVHETMeZm31CtuzOt0PrmZc",
                "y": "sewHrUNpXvJ7k-_4K8Yq78KgKzT1Vb7kmhK8x7_6h0g"
            }
        }
    ],
    "authentication": [
        "#a2518db3b6b44332b3b667928a51b0cavcSigningKey-f0a5b"
    ],
    "assertionMethod": [
        "#a2518db3b6b44332b3b667928a51b0cavcSigningKey-f0a5b"
    ]
}*/
}
