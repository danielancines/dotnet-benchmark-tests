using System.Diagnostics;
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
    {
        this.Names = new();
        this.NamesArray = new int[SIZE];

        for (int i = 0; i < SIZE; i++)
        {
            this.Names.Add(i);
            this.NamesArray[i] = i;
        }
    }
    // [Benchmark]
    // public void Test_Array()
    // {
    //     var total = 0;
    //     foreach (var number in this.NamesArray)
    //     {
    //         total += number;
    //     }
    // }
    //
    // [Benchmark]
    // public void Test_List()
    // {
    //     var total = 0;
    //     foreach (var number in this.Names)
    //     {
    //         total += number;
    //     }
    // }

    [Benchmark]
    public void Test_Search_On_Array_ForLoop()
    {
        var searchTerm = 34000;
        for (int i = 0; i < this.NamesArray.Length; i++)
        {
            if (searchTerm == this.NamesArray[i])
                break;
        }
    }
    
    [Benchmark]
    public void Test_Search_On_Array_ForEachLoop()
    {
        var searchTerm = 34000;
        foreach (var number in this.NamesArray)
        {
            if (number == searchTerm)
                break;
        }
    }
    
    [Benchmark]
    public void Test_Search_On_Array_LINQ()
    {
        var searchTerm = 34000;
        var result = this.NamesArray.FirstOrDefault(n => n == searchTerm);
    }
    
    [Benchmark]
    public void Test_Search_On_List_LINQ()
    {
        var searchTerm = 34000;
        var result = this.Names.FirstOrDefault(n => n == searchTerm);
    }
    
    [Benchmark]
    public void Test_Search_On_List_ForeachLoop()
    {
        var searchTerm = 34000;
        foreach (var name in this.Names)
        {
            if (searchTerm == name)
                break;
        }
    }
}