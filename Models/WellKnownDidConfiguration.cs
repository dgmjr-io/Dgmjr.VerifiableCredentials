namespace Dgmjr.VerifiableCredentials.Models;
using System;


public class WellKnownDidConfiguration
{
    [JProp("@context")]
    public Uri Context { get; set; } = new("https://identity.foundation/.well-known/contexts/did-configuration-v0.0.jsonld");

    [JProp("linked_dids")]
    public string[] LinkedDids { get; set; } = Array.Empty<string>();
}
