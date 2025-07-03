using System.Text.Json;
using System.Text.Json.Serialization;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json;

[JsonConverter(typeof(PortJsonConverter))]
public sealed class Port(ushort address, byte value, PortType portType)
{
    public ushort Address { get; } = address;

    public byte Value { get; } = value;

    public PortType Type { get; } = portType;

    private sealed class PortJsonConverter : JsonConverter<Port>
    {
        public override Port Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();
            var port = reader.GetUInt16();

            reader.Read();
            var value = reader.GetByte();

            reader.Read();
            var typeString = reader.GetString();
            var type = typeString switch
            {
                "r" => PortType.Input,
                "w" => PortType.Output,
                _ => throw new NotSupportedException("The port type \"{typeString}\" is not supported.")
            };

            reader.Read();
            return new Port(port, value, type);
        }

        public override void Write(Utf8JsonWriter writer, Port value, JsonSerializerOptions options) => throw new NotSupportedException();
    }
}