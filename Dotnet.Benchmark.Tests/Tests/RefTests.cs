using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests
{
    [MemoryDiagnoser]
    public class RefTests
    {
        List<Person1> _persons = new List<Person1>();
        List<Person2> _people = new List<Person2>();

        [GlobalSetup]
        public void Initialize()
        {
            for (int i = 0; i < 1000; i++)
            {
                _persons.Add(new Person1() { Name = i.ToString() });
                _people.Add(new Person2() { Name = i.ToString() });
            }
        }

        [Benchmark]
        public void Struct_Normal()
        {
            foreach (Person1 person in _persons)
            {
                NormalInteraction(person);
            }
        }

        private void NormalInteraction(Person1 person)
        {
            person.Name = "Test";
        }

        [Benchmark(Baseline = true)]
        public void Struct_Refs()
        {
            for (int i = 0; i < _persons.Count; i++)
            {
                var p = _persons[i];
                RefInteraction(ref p);
            }
        }

        private void RefInteraction(ref Person1 person)
        {
            person.Name = "Test";
        }

        [Benchmark]
        public void Class_Refs()
        {
            for (int i = 0; i < _people.Count; i++)
            {
                var p = _people[i];
                RefClassInteraction(ref p);
            }
        }

        private void RefClassInteraction(ref Person2 person)
        {
            person.Name = "Test";
        }

        [Benchmark]
        public void Class_Normal()
        {
            for (int i = 0; i < _people.Count; i++)
            {
                var p = _people[i];
                ClassInteraction(p);
            }
        }

        private void ClassInteraction(Person2 person)
        {
            person.Name = "Test";
        }
    }

    public struct Person1
    {
        public string Name { get; set; }
    }

    public class Person2
    {
        public string Name { get; set; }
    }
}
