using System.Text.Json;
using System.Text.Json.Serialization;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.M6502;

[JsonConverter(typeof(CycleJsonConverter))]
public sealed class Cycle(ushort address, byte value, bool isWrite)
{
    public ushort Address { get; } = address;

    public byte Value { get; } = value;

    public bool IsWrite { get; } = isWrite;

    private sealed class CycleJsonConverter : JsonConverter<Cycle>
    {
        public override Cycle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            reader.Read();
            var address = reader.GetUInt16();

            reader.Read();
            var value = reader.GetByte();

            reader.Read();
            var typeString = reader.GetString()!;

            reader.Read();
            return new Cycle(address, value, typeString switch
            {
                "read" => false,
                "write" => true,
                _ => throw new NotSupportedException($"The cycle type \"{typeString}\" is not supported.")
            });
        }

        public override void Write(Utf8JsonWriter writer, Cycle value, JsonSerializerOptions options) => throw new NotSupportedException();
    }
}