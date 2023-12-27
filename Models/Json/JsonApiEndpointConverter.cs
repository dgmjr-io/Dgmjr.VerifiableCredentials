namespace Dgmjr.VerifiableCredentials.Json;

public class JsonApiEndpointUriStringConverter
    : System.Text.Json.Serialization.JsonConverter<Models.ApiEndpointUri>
{
    public override bool CanConvert(type typeToConvert) =>
        typeToConvert == typeof(Models.ApiEndpointUri);

    public override Models.ApiEndpointUri Read(
        ref Utf8JsonReader reader,
        type typeToConvert,
        Jso options
    )
    {
        return new(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, Models.ApiEndpointUri value, Jso options)
    {
        writer.WriteStringValue(value.ToString());
    }
}

public class JsonApiEndpointUriStringAttribute : JConverterAttribute
{
    public override JConverter CreateConverter(type typeToConvert)
    {
        return new JsonApiEndpointUriStringConverter();
    }
}
