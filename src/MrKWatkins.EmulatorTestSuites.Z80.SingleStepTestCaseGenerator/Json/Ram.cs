using System.Text.Json;
using System.Text.Json.Serialization;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json;

[JsonConverter(typeof(PortJsonConverter))]
public sealed record Ram(ushort Address, byte Value)
{
    private sealed class PortJsonConverter : JsonConverter<Ram>
    {
        public override Ram Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();
            var port = reader.GetUInt16();

            reader.Read();
            var value = reader.GetByte();

            reader.Read();
            return new Ram(port, value);
        }

        public override void Write(Utf8JsonWriter writer, Ram value, JsonSerializerOptions options) => throw new NotSupportedException();
    }
}