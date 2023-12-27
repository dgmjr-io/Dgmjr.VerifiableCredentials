namespace Dgmjr.VerifiableCredentials.Models;
using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using IImage = Microsoft.Maui.Graphics.IImage;
using Extensions;

public record class VCLogo
{
    [JProp("uri")]
    public Uri Uri { get; set; }

    [JProp("description")]
    public string Description { get; set; }

    public float Height => Image.Height;
    public float Width => Image.Width;
    public byte[] Data => Uri.OpenRead().ReadAllBytes();

    private IImage _image;

    [JIgnore]
    public IImage Image => _image ??= PlatformImage.FromStream(Uri.OpenRead());
}
