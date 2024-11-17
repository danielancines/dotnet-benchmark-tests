using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class OffTypeVsIsPatternTests
{
    private List<object> _objects = new List<object>();

    [GlobalSetup]
    public void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
                this._objects.Add("Daniel");
            else
                this._objects.Add(10);
        }
    }

    [Benchmark(Baseline = true)]
    public void OfType()
    {
        var firstString = this._objects.OfType<string>().FirstOrDefault();
        var firstInt = this._objects.OfType<int>().FirstOrDefault();
    }

    [Benchmark]
    public void IsPattern()
    {
        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i] is string)
            {
                break;
            }
        }

        for (int i = 0; i < _objects.Count; i++)
        {
            if (_objects[i] is int)
            {
                break;
            }
        }
    }
}
