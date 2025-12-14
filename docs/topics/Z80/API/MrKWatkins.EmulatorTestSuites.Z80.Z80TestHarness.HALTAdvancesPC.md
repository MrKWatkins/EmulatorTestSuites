# Z80TestHarness.HALTAdvancesPC Property
## Definition

Does the HALT instruction advance PC?

```c#
protected virtual bool HALTAdvancesPC { get; }
```

## Property Value

[Boolean](https://learn.microsoft.com/en-gb/dotnet/api/System.Boolean)
## Remarks

Some Z80 emulators do not advance the PC after a HALT instruction, but the official documentation states that it does. This property is used when writing debug information; if `true` then PC will be decremented before writing debug information, so that HALT is written to the logs, then restored afterwards. `true` by default.
