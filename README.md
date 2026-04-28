# Dotnet Benchmark Tests

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![C#](https://img.shields.io/badge/C%23-14.0-239120?style=flat&logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-14)

A collection of micro-benchmarks built with [BenchmarkDotNet](https://benchmarkdotnet.org/) exploring performance characteristics of various .NET features and patterns.

## Benchmarks

- [JsonSerializer Source Generator Tests](./JsonSerializerSourceGeneratorTests.md) — Comparison between standard `System.Text.Json` reflection-based (de)serialization and the source-generated equivalents.
