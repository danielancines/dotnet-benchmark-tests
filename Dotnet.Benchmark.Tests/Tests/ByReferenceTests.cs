using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class ByReferenceTests
{
    private List<Person> _people = new();
    [GlobalSetup]
    public void StartUp()
    {
        for (int i = 0; i < 1000; i++)
        {
            _people.Add(new Person(i.ToString()));
        }
    }

    [GlobalCleanup]
    public void CleanUp()
    {
        
    }

    [Benchmark]
    public void ByReference()
    {
        foreach (var person in this._people)  
        {
            
        }
    }
    
    private void ByReference(ref string name)
    {
        name = "Daniel Changed ByRef";
    }
}