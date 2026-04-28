// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Dotnet.Benchmark.Tests.Tests;

BenchmarkRunner.Run<JsonSerializerSourceGeneratorTests>();