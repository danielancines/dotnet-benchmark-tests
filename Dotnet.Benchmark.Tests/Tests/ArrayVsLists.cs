using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser()]
public class ArrayVsLists
{
    private const long SIZE = 3000000;
    public List<int> Names { get; set; }
    public int[] NamesArray { get; set; }
    [GlobalSetup]
    public void Setup()
    {›
        this.Names = new();
        this.NamesArray = new int[SIZE];

        for (int i = 0; i < SIZE; i++)
        {
            this.Names.Add(i);
            this.NamesArray[i] = i;
        }
    }
    [Benchmark]
    public void Test_Array()
    {
        var total = 0;
        foreach (var number in this.NamesArray)
        {
            total += number;
        }
    }
    
    [Benchmark]
    public void Test_List()
    {
        var total = 0;
        foreach (var number in this.Names)
        {
            total += number;
        }
    }

}