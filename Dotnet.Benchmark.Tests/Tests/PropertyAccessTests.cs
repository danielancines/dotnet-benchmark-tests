using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class PropertyAccessTests
{
    List<int> _list = new();
    [GlobalSetup]
    public void Setup()
    {
        for (int i = 0; i < 1341; i++)
        {
            this._list.Add(i);
        }
    }


    [Benchmark]
    public void Property_on_method()
    {
        var count = this._list.Count;
        for (int i = 0; i < 1000; i++)
        {
            if (count % 2 == 0)
            {

            }
        }
    }

    [Benchmark(Baseline = true)]
    public void ListProperty()
    {
        for (int i = 0; i < 1000; i++)
        {
            if (this._list.Count % 2 == 0)
            {

            }
        }
    }

    [Benchmark]
    public void ListProperty_IEnumerable()
    {
        for (int i = 0; i < 1000; i++)
        {
            if (this._list.Count() % 2 == 0)
            {

            }
        }
    }
}
