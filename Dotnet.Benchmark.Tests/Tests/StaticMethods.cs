using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class StaticMethods
{
    //private MyStaticTestClass myClass = new MyStaticTestClass();
    List<MyStaticTestClass> _testClasses = new();
    public void Initialize()
    {
        for (int i = 0; i < 100000; i++)
        {
            _testClasses.Add(new MyStaticTestClass());
        }
    }

    [Benchmark(Baseline = true)]
    public void TestConcrete()
    {
        foreach (var testClass in _testClasses)
            testClass.Sum(Random.Shared.Next(), Random.Shared.Next());
        foreach (var testClass in _testClasses)
            testClass.Sum(Random.Shared.Next(), Random.Shared.Next());
        foreach (var testClass in _testClasses)
            testClass.Sum(Random.Shared.Next(), Random.Shared.Next());

    }

    [Benchmark(Baseline = false)]
    public void TestStatic()
    {
        foreach (var testClass in _testClasses)
            testClass.StaticSum(Random.Shared.Next(), Random.Shared.Next());
        foreach (var testClass in _testClasses)
            testClass.StaticSum(Random.Shared.Next(), Random.Shared.Next());
        foreach (var testClass in _testClasses)
            testClass.StaticSum(Random.Shared.Next(), Random.Shared.Next());

    }
}

public class MyStaticTestClass
{
    public int Sum(int num, int num1)
    {
        var result = num + num1;
        for (int i = 0; i < 1000; i++)
        {
            if (IsOdd(result))
                result = result + 1;
        }

        return result;
    }

    private bool IsOdd(int num) => num % 2 == 0;

    public int StaticSum(int num, int num1)
    {
        var result = num + num1;
        for (int i = 0; i < 1000; i++)
        {
            if (IsEven(result))
                result = result + 1;
        }

        return result;
    }

    private static bool IsEven(int num) => num % 2 == 0;
}
