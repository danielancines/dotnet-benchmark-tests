```

BenchmarkDotNet v0.13.8, macOS Ventura 13.5.2 (22G91) [Darwin 22.6.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 7.0.307
  [Host]     : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), Arm64 RyuJIT AdvSIMD


```
| Method     | Mean     | Error     | StdDev    | Allocated |
|----------- |---------:|----------:|----------:|----------:|
| Test_Array | 1.225 ms | 0.0023 ms | 0.0021 ms |       2 B |
| Test_List  | 2.827 ms | 0.0045 ms | 0.0040 ms |       4 B |
