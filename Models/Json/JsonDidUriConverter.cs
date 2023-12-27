namespace Dgmjr.VerifiableCredentials.Json;
using Models;

public class JsonDidUriConverter : System.Text.Json.Serialization.JsonConverter<DidUri>
{
    public override bool CanConvert(type typeToConvert) =>
        typeToConvert == typeof(DidUri);

    public override DidUri Read(
        ref Utf8JsonReader reader,
        type typeToConvert,
        Jso options
    )
    {
        return new(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, DidUri value, Jso options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
