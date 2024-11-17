using BenchmarkDotNet.Attributes;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class JsonSerializerContextTest
{
    List<string> _list = new List<string>();
    string personJson = "{ \"Property1\": \"Value1\", \"Property2\": \"Value2\", \"Property3\": \"Value3\", \"Property4\": \"Value4\", \"Property5\": \"Value5\", \"Property6\": \"Value6\", \"Property7\": \"Value7\", \"Property8\": \"Value8\", \"Property9\": \"Value9\", \"Property10\": \"Value10\", \"Property11\": \"Value11\", \"Property12\": \"Value12\", \"Property13\": \"Value13\", \"Property14\": \"Value14\", \"Property15\": \"Value15\", \"Property16\": \"Value16\", \"Property17\": \"Value17\", \"Property18\": \"Value18\", \"Property19\": \"Value19\", \"Property20\": \"Value20\", \"Property21\": \"Value21\", \"Property22\": \"Value22\", \"Property23\": \"Value23\", \"Property24\": \"Value24\", \"Property25\": \"Value25\", \"Property26\": \"Value26\", \"Property27\": \"Value27\", \"Property28\": \"Value28\", \"Property29\": \"Value29\", \"Property30\": \"Value30\", \"Property31\": \"Value31\", \"Property32\": \"Value32\", \"Property33\": \"Value33\", \"Property34\": \"Value34\", \"Property35\": \"Value35\", \"Property36\": \"Value36\", \"Property37\": \"Value37\", \"Property38\": \"Value38\", \"Property39\": \"Value39\", \"Property40\": \"Value40\"}";

    [GlobalSetup]
    public void Setup()
    {
    }

    [Benchmark(Baseline = true)]
    public void Reflection_Serializer()
    {
        for (int i = 0; i < 1; i++)
        {
            var person = JsonSerializer.Deserialize(personJson, PersonContext.Default.JsonSerializerContext_Person);
        }
    }

    [Benchmark]
    public void JsonContext_Serializer()
    {
        for (int i = 0; i < 1; i++)
        {
            var person = JsonSerializer.Deserialize<JsonSerializerContext_Person>(personJson);
        }
    }
}

[JsonSerializable(typeof(JsonSerializerContext_Person))]
partial class PersonContext : JsonSerializerContext { };

record JsonSerializerContext_Person(string Property1, string Property2, string Property3, string Property4, string Property5, string Property6, string Property7, string Property8, string Property9, string Property10, string Property11, string Property12, string Property13, string Property14, string Property15, string Property16, string Property17, string Property18, string Property19, string Property20, string Property21, string Property22, string Property23, string Property24, string Property25, string Property26, string Property27, string Property28, string Property29, string Property30, string Property31, string Property32, string Property33, string Property34, string Property35, string Property36, string Property37, string Property38, string Property39, string Property40);
