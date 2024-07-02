using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class SealedClassesTests
{
    List<BaseClass> _sealedClasses = new();
    List<BaseClass> _nonSealedClasses = new();
    BaseClass _baseClass = new();

    BaseClass _sealedClass = new SealedClass();
    BaseClass _nonSealedClass = new NonSealedClass();

    [GlobalSetup]
    public void Setup()
    {
        for (int i = 0; i < 10000; i++)
        {
            this._sealedClasses.Add(new BaseClass()
            {
            });

            this._nonSealedClasses.Add(new BaseClass()
            {
            });

        }
    }

    [Benchmark(Baseline = true)]
    public void NonSealedClassesMethod()
    {
        foreach (var item in _nonSealedClasses)
        {
            item.Method();
        }
    }

    [Benchmark]
    public void SealedClassesMethod()
    {
        foreach (var item in _sealedClasses)
        {
            item.Method();
        }
    }

    //[Benchmark]
    //public bool Is_Sealed() => this._baseClass is SealedClass;

    //[Benchmark(Baseline = true)]
    //public bool Is_NonSealed() => this._baseClass is NonSealedClass;

    [Benchmark]
    public void NonSealed()
    {
       (this._nonSealedClass as NonSealedClass).Name = "Daniel";
    }

    [Benchmark]
    public void Sealed()
    {
        (this._sealedClass as SealedClass).Name = "Daniel";
    }
}

public class BaseClass
{
    public virtual void Method() { }
}

public sealed class SealedClass : BaseClass
{
    public override void Method()
    {
        base.Method();
    }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}

public class NonSealedClass : BaseClass
{
    public override void Method()
    {
        base.Method();
    }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
}
