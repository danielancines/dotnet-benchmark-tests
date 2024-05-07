using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class SealedClassesTests
{
    List<BaseClass> _sealedClasses = new();
    List<BaseClass> _nonSealedClasses = new();
    BaseClass _baseClass = new();

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

    //[Benchmark(Baseline = true)]
    //public void NonSealedClassesMethod()
    //{
    //    foreach (var item in _nonSealedClasses)
    //    {
    //        item.Method();
    //    }
    //}

    //[Benchmark]
    //public void SealedClassesMethod()
    //{
    //    foreach (var item in _nonSealedClasses)
    //    {
    //        item.Method();
    //    }
    //}

    [Benchmark]
    public bool Is_Sealed() => this._baseClass is SealedClass;

    [Benchmark(Baseline = true)]
    public bool Is_NonSealed() => this._baseClass is NonSealedClass;

    //[Benchmark(Baseline = true)]
    //public void NonSealed()
    //{
    //    foreach (var item in this._nonSealedClasses)
    //    {
    //        if (item is NonSealedClass)
    //        {

    //        }
    //    }
    //}

    //[Benchmark]
    //public void Sealed()
    //{
    //    foreach (var item in this._sealedClasses)
    //    {
    //        if (item is SealedClass)
    //        {

    //        }
    //    }
    //}
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
