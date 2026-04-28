# Source Generator Tests

Benchmark comparison between standard `System.Text.Json` serialization/deserialization and the source-generated equivalents.

## Tests Performed

The benchmark suite covers two categories of operations, each comparing the runtime-reflection-based approach against the source-generated approach:

### Deserialization
- **Normal_Deserialization** — Standard `JsonSerializer.Deserialize<T>` using runtime reflection.
- **SourceGenerated_Deserialization** — `JsonSerializer.Deserialize` using a `JsonSerializerContext` produced by the source generator.

### Serialization
- **Normal_Serialization** — Standard `JsonSerializer.Serialize<T>` using runtime reflection.
- **SourceGenerated_Serialization** — `JsonSerializer.Serialize` using a `JsonSerializerContext` produced by the source generator.

## Results

| Method                          | Categories      | Mean      | Error    | StdDev   | Ratio | RatioSD | Gen0   | Gen1   | Allocated | Alloc Ratio |
|-------------------------------- |---------------- |----------:|---------:|---------:|------:|--------:|-------:|-------:|----------:|------------:|
| Normal_Deserialization          | Deserialization | 115.95 us | 1.061 us | 0.886 us |  1.00 |    0.01 | 7.5684 | 2.4414 | 141.21 KB |        1.00 |
| SourceGenerated_Deserialization | Deserialization | 108.73 us | 1.239 us | 1.159 us |  0.94 |    0.01 | 7.5684 | 2.5635 | 141.21 KB |        1.00 |
|                                 |                 |           |          |          |       |         |        |        |           |             |
| Normal_Serialization            | Serialization   |  84.23 us | 1.654 us | 2.208 us |  1.00 |    0.04 | 8.0566 | 3.9063 | 148.16 KB |        1.00 |
| SourceGenerated_Serialization   | Serialization   |  67.93 us | 1.067 us | 0.998 us |  0.81 |    0.02 | 8.0566 | 3.9063 | 148.16 KB |        1.00 |

## Summary

- **Deserialization**: The source-generated version is about **6% faster** (ratio 0.94) than the reflection-based version, with no measurable change in allocations.
- **Serialization**: The source-generated version is about **19% faster** (ratio 0.81) than the reflection-based version, again with identical allocations.

In both scenarios, the source generator delivers a measurable throughput improvement while keeping memory usage equivalent to the reflection-based path. The benefit is most pronounced on the serialization side.
