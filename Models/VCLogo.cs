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
    [JIgnore]
    public byte[] Data => Uri.OpenRead().ReadAllBytes();

    private IImage _image;

    [JIgnore]
    public IImage Image
    {
        get
        {
            if(_image == null)
            {
                using var s = Uri.OpenRead();
                _image = PlatformImage.FromStream(s);
            }
            return _image;
        }
    }
}
