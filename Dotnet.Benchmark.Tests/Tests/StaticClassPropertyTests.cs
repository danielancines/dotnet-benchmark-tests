using BenchmarkDotNet.Attributes;
using System.Drawing;

namespace Dotnet.Benchmark.Tests.Tests
{
    [MemoryDiagnoser]
    public class StaticClassPropertyTests
    {
        Color Red = Color.Red;
        Color Green = Color.Green;
        Color Blue = Color.Blue;
        Color Yellow = Color.Yellow;

        [Benchmark(Baseline = true)]
        public void StaticClassProperty()
        {
            for (int i = 0; i < 10000; i++)
            {
                var red = Color.Red;
                var green = Color.Green;
                var blue = Color.Blue;
                var yellow = Color.Yellow;
            }
        }

        [Benchmark]
        public void LocalProperties()
        {
            for (int i = 0; i < 10000; i++)
            {
                var red = this.Red;
                var green = this.Green;
                var blue = this.Blue;
                var yellow = this.Yellow;
            }
        }
    }
}
