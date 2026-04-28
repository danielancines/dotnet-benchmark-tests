using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dotnet.Benchmark.Tests.Tests;

[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[CategoriesColumn]
[MemoryDiagnoser]
public class JsonSerializerSourceGeneratorTests
{
    List<Foo> FooList { get; } = new();
    List<string> FooJson { get; } = new();

    [GlobalSetup]
    public void Intialize()
    {
        for (int i = 0; i < 1000; i++)
        {
            var newFoo = new Foo()
            {
                Name = $"Name_{i}",
                LastName = $"LastName_{i}",
                Age = i,
                Email = $"user_{i}@example.com",
                IsActive = i % 2 == 0,
                Salary = 1000.50m + i,
                Height = 1.70 + (i * 0.001),
                Weight = 70.5f + i,
                BirthDate = new DateTime(1990, 1, 1).AddDays(i),
                LastLogin = DateTimeOffset.UtcNow.AddMinutes(-i),
                Id = Guid.NewGuid(),
                Score = (long)i * 1000,
                Level = (short)(i % short.MaxValue),
                Rating = (byte)(i % 256),
                Initial = (char)('A' + (i % 26)),
                Tags = new List<string> { $"tag_{i}_a", $"tag_{i}_b", $"tag_{i}_c" },
                Scores = new[] { i, i + 1, i + 2 },
                Metadata = new Dictionary<string, string>
                {
                    { "key1", $"value_{i}_1" },
                    { "key2", $"value_{i}_2" }
                },
                Status = (FooStatus)(i % 3),
                Description = i % 5 == 0 ? null : $"Description for item {i}"
            };

            this.FooList.Add(newFoo);
            this.FooJson.Add(JsonSerializer.Serialize(newFoo));
        }
    }

    [BenchmarkCategory("Serialization"), Benchmark(Baseline = true)]
    public void Normal_Serialization()
    {
        List<string> foos = new();
        foreach (var foo in FooList)
        {
            var newFoo = JsonSerializer.Serialize<Foo>(foo);
            if (newFoo != null)
                foos.Add(newFoo);
        }
    }

    [BenchmarkCategory("Serialization"), Benchmark]
    public void SourceGenerated_Serialization()
    {
        List<string> foos = new();
        foreach (var foo in FooList)
        {
            var newFoo = JsonSerializer.Serialize<Foo>(foo, FooContext.Default.Foo);
            if (newFoo != null)
                foos.Add(newFoo);
        }
    }

    [BenchmarkCategory("Deserialization"), Benchmark(Baseline = true)]
    public void Normal_Deserialization()
    {
        List<Foo> foos = new();
        foreach (var fooJson in FooJson)
        {
            var newFoo = JsonSerializer.Deserialize<Foo>(fooJson);
            if (newFoo != null)
                foos.Add(newFoo);
        }
    }

    [BenchmarkCategory("Deserialization"), Benchmark]
    public void SourceGenerated_Deserialization()
    {
        List<Foo> foos = new();
        foreach (var fooJson in FooJson)
        {
            var newFoo = JsonSerializer.Deserialize<Foo>(fooJson, FooContext.Default.Foo);
            if (newFoo != null)
                foos.Add(newFoo);
        }
    }
}

internal sealed class Foo
{
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public string? Email { get; set; }
    public bool IsActive { get; set; }
    public decimal Salary { get; set; }
    public double Height { get; set; }
    public float Weight { get; set; }
    public DateTime BirthDate { get; set; }
    public DateTimeOffset LastLogin { get; set; }
    public Guid Id { get; set; }
    public long Score { get; set; }
    public short Level { get; set; }
    public byte Rating { get; set; }
    public char Initial { get; set; }
    public List<string>? Tags { get; set; }
    public int[]? Scores { get; set; }
    public Dictionary<string, string>? Metadata { get; set; }
    public FooStatus Status { get; set; }
    public string? Description { get; set; }
}

internal enum FooStatus
{
    Inactive,
    Active,
    Pending
}

[JsonSerializable(typeof(Foo))]
internal partial class FooContext : JsonSerializerContext { }


