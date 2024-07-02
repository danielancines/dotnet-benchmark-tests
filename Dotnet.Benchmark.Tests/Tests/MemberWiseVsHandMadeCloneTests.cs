using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class MemberWiseVsHandMadeCloneTests
{
    [Benchmark(Baseline = true)]
    public void HandMadeClone()
    {
        var person = new Person();
        var newPerson = (Person)person.Clone();
    }

    [Benchmark]
    public void MemberWiseClone()
    {
        var person = new Person();
        var newPerson = person.DeepClone();
    }

    class Person : ICloneable
    {
        public string MyProperty { get; set; }
        public string MyProperty1 { get; set; }
        public string MyProperty2 { get; set; }
        public string MyProperty3 { get; set; }
        public string MyProperty4 { get; set; }
        public string MyProperty5 { get; set; }
        public string MyProperty6 { get; set; }
        public string MyProperty7 { get; set; }
        public string MyProperty8 { get; set; }

        public object Clone()
        {
            return new Person { MyProperty = MyProperty, MyProperty1 = MyProperty1, MyProperty2 = MyProperty2, MyProperty3 = MyProperty3, MyProperty4 = MyProperty4, MyProperty5 = MyProperty5, MyProperty6 = MyProperty6, MyProperty7 = MyProperty7, MyProperty8 = MyProperty8 };
        }

        public Person DeepClone()
        {
            return (Person)this.MemberwiseClone();
        }
    }

}
