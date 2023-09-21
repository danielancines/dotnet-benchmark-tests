using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser()]
public class BoxUnboxing
{
    public object[] Numbers { get; set; }
    public object[] PersonsObjects { get; set; }

    public List<Person> Persons { get; } = new();
    [GlobalSetup]
    public void Setup()
    {
        this.Numbers = new object[3000];
        this.PersonsObjects = new object[3000];
        
        for (int i = 0; i < 3000; i++)
        {
            this.Numbers[i] = i;
            this.PersonsObjects[i] = new Person(i.ToString());
            this.Persons.Add(new Person(i.ToString()));
        }
    }

    [Benchmark]
    public void Unbox_Value_Types_Explicit()
    {
        var sum = 0;
        foreach (var number in this.Numbers)
            sum += (int)number;
    }
    
    [Benchmark]
    public void Unbox_Value_Types_Parse()
    {
        var sum = 0;
        foreach (var number in this.Numbers)
            sum += int.Parse(number.ToString());
    }
    
    [Benchmark]
    public void Unbox_Reference_Types_Explicit()
    {
        Person person;
        foreach (var personObj in this.PersonsObjects)
            person = (Person)personObj;
    }
    
    [Benchmark]
    public void NoUnbox_Reference_Types()
    {
        Person person;
        foreach (var personObj in this.Persons)
            person = personObj;
    }
}

public class Person
{
    public Person(string name)
    {
        this.Name = name;
    }
    public string Name { get; set; }
}