# Z80TestHarness.SetIO Method
## Definition

Sets both the IO reader and writer to the same implementation.

```c#
public void SetIO<TIO>(TIO io)
   where TIO : IIOReader, IIOWriter;
```

### Type Parameters

| Name | Description |
| ---- | ----------- |
| TIO | The type of the IO implementation. |

## Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| io | TIO | The IO implementation. |

