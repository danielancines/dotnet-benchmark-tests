using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class TryCatchTests
{
    [Benchmark]
    public void With_Try_Catch()
    {
        var count = 0;
        for (int i = 0; i < 10000; i++)
        {
            try
            {
                count += i;
            }
            catch (Exception ex)
            {

            }
        }
    }

    [Benchmark]
    public void With_Try_Catch_Throwing_Exception()
    {
        var count = 0;
        for (int i = 0; i < 10000; i++)
        {
            try
            {
                count += i;
                if (Random.Shared.Next() % 2 == 0)
                    throw new Exception();
            }
            catch (Exception ex)
            {

            }
        }
    }

    [Benchmark(Baseline = true)]
    public void No_Try_Catch()
    {
        var count = 0;
        for (int i = 0; i < 10000; i++)
        {
            count += i;
        }
    }
}
