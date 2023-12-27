using System.Drawing;

namespace Dgmjr.VerifiableCredentials.Json;

public class JsonHtmlColorConverter
    : System.Text.Json.Serialization.JsonConverter<System.Drawing.Color>
{
    public override System.Drawing.Color Read(
        ref Utf8JsonReader reader,
        type typeToConvert,
        Jso options
    )
    {
        return ColorTranslator.FromHtml(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, System.Drawing.Color value, Jso options)
    {
        writer.WriteStringValue(ColorTranslator.ToHtml(value));
    }
}
