# TestAssertions Enum
## Definition

Flags specifying which aspects of the Z80 processor state should be tested during instruction execution.

```c#
public enum TestAssertions
```

## Fields

| Name | Description |
| ---- | ----------- |
| [A](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the A register. |
| [All](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test everything. |
| [AllExceptCycles](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test everything except [Cycles](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields). |
| [BC](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the BC register pair. |
| [C](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the carry flag, C. |
| [Cycles](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test machine cycles. |
| [DE](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the DE register pair. |
| [DocumentedFlags](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the documented flags, [C](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields), [N](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields), [P/V](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields), [H](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields), [Z](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) and [S](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields). |
| [F](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the F register. |
| [Flags](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test all the flags. |
| [H](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the half-carry flag, H. |
| [Halted](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test whether the CPU is in the halted state. |
| [HL](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the HL register pair. |
| [I](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the I register. |
| [IFF1](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the IFF1 interrupt flip-flop. |
| [IFF2](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the IFF2 interrupt flip-flop. |
| [IM](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the interrupt mode. |
| [Interrupts](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test all the interrupt-related properties, [IFF1](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields), [IFF2](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields), [IM](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) and [Halted](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields). |
| [IO](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test both I/O read and write operations. |
| [IOReads](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test I/O read operations. |
| [IOWrites](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test I/O write operations. |
| [IX](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the IX register pair. |
| [IY](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the IY register pair. |
| [Memory](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test memory state. |
| [N](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the add/subtract flag, N. |
| [None](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test nothing. Kinda pointless really. |
| [PC](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the PC register. |
| [PV](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the parity/overflow flag, P/V. |
| [Q](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the internal Q register. |
| [R](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the R register. |
| [Registers](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Tests all the registers. |
| [RegistersExceptQ](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Tests all the registers except [Q](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields). |
| [RegistersExceptWZAndQ](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Tests all the non-internal registers, i.e. all registers except [WZ](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) and [Q](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields). |
| [S](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the sign flag, S. |
| [ShadowAF](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the AF&#39; register pair. |
| [ShadowBC](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the BC&#39; register pair. |
| [ShadowDE](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the DE&#39; register pair. |
| [ShadowHL](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the HL&#39; register pair. |
| [SP](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the SP register. |
| [TStates](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test T-states. |
| [WZ](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the internal WZ register, sometimes called MEMPTR. |
| [X](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the undocumented X flag, bit 3 of the F register. |
| [Y](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the undocumented Y flag, bit 5 of the F register. |
| [Z](MrKWatkins.EmulatorTestSuites.Z80.Instruction.TestAssertions.md#fields) | Test the zero flag, Z. |

