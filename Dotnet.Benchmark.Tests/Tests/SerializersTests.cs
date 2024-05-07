using BenchmarkDotNet.Attributes;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class SerializersTests
{
    public List<string> Messages { get; private set; }
    [GlobalSetup]
    public void Setup()
    {
        this.Messages = new List<string>();

        for (int i = 0; i < 1000; i++)
        {
            this.Messages.Add(JsonSerializer.Serialize(new MessageResponse()
            {
                Message = i.ToString(),
                Topic = $"Topic_{i.ToString()}",
                Topic1 = $"Topic_{i.ToString()}",
                Topic2 = $"Topic_{i.ToString()}",
                Topic3 = $"Topic_{i.ToString()}",
                Topic4 = $"Topic_{i.ToString()}"
            }));
        }
    }

    [Benchmark]
    public void JsonSerializerTest()
    {
        List<MessageResponse> messages = new List<MessageResponse>();
        foreach (var message in this.Messages)
        {
            messages.Add(JsonSerializer.Deserialize<MessageResponse>(message));
        }
    }

    [Benchmark]
    public void JsonNodeDynamicTest()
    {
        List<MessageResponse> messages = new List<MessageResponse>();
        foreach (var message in this.Messages)
        {
            dynamic json = JsonNode.Parse(message);
            messages.Add(new MessageResponse()
            {
                Message = json["Message"],
                Topic = (string)json["Topic"],
                Topic1 = (string)json["Topic1"],
                Topic2 = (string)json["Topic2"],
                Topic3 = (string)json["Topic3"],
                Topic4 = (string)json["Topic4"]
            });
        }
    }

    [Benchmark(Baseline = true)]
    public void JsonNodeTest()
    {
        List<MessageResponse> messages = new List<MessageResponse>();
        foreach (var message in this.Messages)
        {
            var json = JsonNode.Parse(message);
            messages.Add(new MessageResponse()
            {
                Message = (string)json["Message"],
                Topic = (string)json["Topic"],
                Topic1 = (string)json["Topic1"],
                Topic2 = (string)json["Topic2"],
                Topic3 = (string)json["Topic3"],
                Topic4 = (string)json["Topic4"]
            });
        }
    }
}

public class MessageResponse
{
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("topic")]
    public string Topic { get; set; }

    [JsonPropertyName("topic1")]
    public string Topic1 { get; set; }

    [JsonPropertyName("topic2")]
    public string Topic2 { get; set; }

    [JsonPropertyName("topic3")]
    public string Topic3 { get; set; }

    [JsonPropertyName("topic4")]
    public string Topic4 { get; set; }
}

