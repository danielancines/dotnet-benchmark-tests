using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests
{
    [MemoryDiagnoser]
    public class LoopsTests
    {
        List<int> _loops;

        [GlobalSetup]
        public void Setup()
        {
            _loops = new List<int>();
            while (_loops.Count < 1000)
            {
                _loops.Add(Random.Shared.Next(0, 5000));
            }
        }

        [Benchmark(Baseline = true)]
        public void While_Test()
        {
            var count = 0;
            while (count < this._loops.Count)
            {
                count++;
            }
        }

        [Benchmark]
        public void ForEach_Test()
        {
            foreach (var loop in _loops)
            {
            }
        }


        [Benchmark]
        public void For_Test()
        {
            for (int i = 0; i < this._loops.Count; i++)
            {

            }
        }
    }
}
