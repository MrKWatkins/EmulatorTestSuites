using System.Text.Json;
using System.Text.Json.Serialization;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json;

[JsonConverter(typeof(CycleJsonConverter))]
public sealed class Cycle(ushort address, byte? data, Pins pins)
{
    public ushort Address { get; } = address;

    public byte? Data { get; } = data;

    public Pins Pins { get; } = pins;

    private sealed class CycleJsonConverter : JsonConverter<Cycle>
    {
        public override Cycle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();
            var port = reader.GetUInt16();

            reader.Read();
            var data = reader.TokenType != JsonTokenType.Null ? reader.GetByte() : (byte?)null;

            reader.Read();
            var typeString = reader.GetString()!;

            var pins = Pins.None;
            if (typeString[0] == 'r')
            {
                pins |= Pins.Read;
            }

            if (typeString[1] == 'w')
            {
                pins |= Pins.Write;
            }

            if (typeString[2] == 'm')
            {
                pins |= Pins.Memory;
            }

            if (typeString[3] == 'i')
            {
                pins |= Pins.IO;
            }

            reader.Read();
            return new Cycle(port, data, pins);
        }

        public override void Write(Utf8JsonWriter writer, Cycle value, JsonSerializerOptions options) => throw new NotSupportedException();
    }
}