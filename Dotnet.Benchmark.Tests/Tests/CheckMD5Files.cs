using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Security.Cryptography;

namespace Dotnet.Benchmark.Tests.Tests;

[MemoryDiagnoser]
public class CheckMD5Files
{
    private const string ORIGINAL_PATH = "C:\\Users\\danie\\Videos\\Escape From Tarkov";
    private const string COPY_PATH = "C:\\Users\\danie\\Videos\\Escape From Tarkov - Copy";
    public void Initialize()
    {
    }

    [Benchmark(Baseline = true)]
    public void CheckMD5()
    {
        foreach (var file in Directory.GetFiles(ORIGINAL_PATH))
            this.IsEqual(file, Path.Combine(COPY_PATH, Path.GetFileName(file)));
    }

    private bool IsEqual(string file, string file2)
    {
        using (var hashAlgorithm = MD5.Create())
        using (var fileStream1 = File.OpenRead(file))
        using (var fileStream2 = File.OpenRead(file2))
        {
            byte[] hash1 = hashAlgorithm.ComputeHash(fileStream1);
            byte[] hash2 = hashAlgorithm.ComputeHash(fileStream2);

            return StructuralComparisons.StructuralEqualityComparer.Equals(hash1, hash2);
        }
    }
}
