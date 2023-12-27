using System.Drawing;

namespace Dgmjr.VerifiableCredentials.Models;

public record class VCCard
{
    [JProp("title")]
    public string Title { get; set; }

    [JProp("issuedBy")]
    public string IssuedBy { get; set; }

    [JProp("backgroundColor")]
    public System.Drawing.Color BackgroundColor { get; set; }

    [JProp("textColor")]
    public System.Drawing.Color TextColor { get; set; }

    [JProp("logo")]
    public VCLogo Logo { get; set; }

    [JProp("description")]
    public string Description { get; set; }

    [JProp("consent")]
    public VCConsent Consent { get; set; }
}
