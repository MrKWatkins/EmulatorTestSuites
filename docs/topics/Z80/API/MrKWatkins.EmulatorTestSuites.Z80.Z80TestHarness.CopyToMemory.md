# Z80TestHarness.CopyToMemory Method
## Overloads

| Name | Description |
| ---- | ----------- |
| [CopyToMemory(UInt16, ReadOnlySpan&lt;Byte&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CopyToMemory.md#mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-readonlyspan((system-byte)))) | Copies a span of bytes into the memory starting at the specified address. |
| [CopyToMemory(UInt16, IReadOnlyList&lt;Byte&gt;)](MrKWatkins.EmulatorTestSuites.Z80.Z80TestHarness.CopyToMemory.md#mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-collections-generic-ireadonlylist((system-byte)))) | Copies a sequence of bytes into memory starting at the specified address. |

## CopyToMemory(UInt16, ReadOnlySpan&lt;Byte&gt;) {id="mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-readonlyspan((system-byte)))"}

Copies a span of bytes into the memory starting at the specified address.

```c#
public virtual void CopyToMemory(ushort address, ReadOnlySpan<Byte> source);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-readonlyspan((system-byte)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) | The starting address in memory where the bytes will be copied. |
| source | [ReadOnlySpan&lt;Byte&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.ReadOnlySpan-1) | The span of bytes to copy into memory. |

## CopyToMemory(UInt16, IReadOnlyList&lt;Byte&gt;) {id="mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-collections-generic-ireadonlylist((system-byte)))"}

Copies a sequence of bytes into memory starting at the specified address.

```c#
public virtual void CopyToMemory(ushort address, IReadOnlyList<Byte> source);
```

## Parameters {id="parameters-mrkwatkins-emulatortestsuites-z80-z80testharness-copytomemory(system-uint16-system-collections-generic-ireadonlylist((system-byte)))"}

| Name | Type | Description |
| ---- | ---- | ----------- |
| address | [UInt16](https://learn.microsoft.com/en-gb/dotnet/api/System.UInt16) | The starting memory address where the bytes will be copied. |
| source | [IReadOnlyList&lt;Byte&gt;](https://learn.microsoft.com/en-gb/dotnet/api/System.Collections.Generic.IReadOnlyList-1) | The sequence of bytes to copy into memory. |

