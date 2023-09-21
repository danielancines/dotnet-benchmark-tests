// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using Dotnet.Benchmark.Tests.Tests;

Console.WriteLine("Hello, World!");
BenchmarkRunner.Run<BoxUnboxing>();