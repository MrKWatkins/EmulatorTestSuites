using System.IO.Compression;
using System.Runtime.CompilerServices;
using System.Text.Json;
using MrKWatkins.OakAsm.Testing;

namespace MrKWatkins.EmulatorTestSuites.Z80.SingleStepTestCaseGenerator.Json.M6502;

public static class JsonTestCases
{
    [Pure]
    public static async IAsyncEnumerable<(string Name, IReadOnlyList<TestStep> Steps)> EnumerateTestCases([EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var jsonTemp = new DirectoryInfo(Paths.M6502JsonTemp);
        if (!RequiresDownload(jsonTemp))
        {
            await Download(jsonTemp, cancellationToken);
        }

        foreach (var json in jsonTemp.EnumerateFiles("*.json", SearchOption.TopDirectoryOnly))
        {
            yield return (Path.GetFileNameWithoutExtension(json.Name), await LoadJson(json, cancellationToken));
        }
    }

    [Pure]
    private static async Task<IReadOnlyList<TestStep>> LoadJson(FileInfo json, CancellationToken cancellationToken)
    {
        await using var stream = File.OpenRead(json.FullName);
        var steps = await JsonSerializer.DeserializeAsync<TestStep[]>(stream, cancellationToken: cancellationToken);
        return steps!;
    }

    [Pure]
    private static bool RequiresDownload(DirectoryInfo jsonTemp) => jsonTemp.Exists && jsonTemp.EnumerateFiles("*.json", SearchOption.TopDirectoryOnly).Any();

    private static async Task Download(DirectoryInfo jsonTemp, CancellationToken cancellationToken = default)
    {
        using var zip = await DownloadRepository(cancellationToken);

        await ExtractTests(jsonTemp, zip, cancellationToken);
    }

    [MustDisposeResource]
    private static async Task<TemporaryFile> DownloadRepository(CancellationToken cancellationToken)
    {
        var uri = new Uri("https://github.com/SingleStepTests/65x02/archive/refs/heads/main.zip");
        var temporaryFile = TemporaryFile.Create("SingleStepTests65x02.zip");

        Console.WriteLine($"Downloading {uri} to temporary file {temporaryFile.Path}");
        // ReSharper disable once ShortLivedHttpClient
        using var client = new HttpClient();
        await using var repository = await client.GetStreamAsync(uri, cancellationToken);

        await using var file = temporaryFile.OpenWrite();
        await repository.CopyToAsync(file, cancellationToken);

        return temporaryFile;
    }

    private static async Task ExtractTests(DirectoryInfo jsonTemp, TemporaryFile repository, CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Extracting tests from {repository.Path} to directory {jsonTemp.FullName}...");

        jsonTemp.Create();

        await using var zipStream = repository.OpenRead();
        await using var zip = new ZipArchive(zipStream, ZipArchiveMode.Read);

        var testEntries = zip.Entries.Where(e =>
            !string.IsNullOrWhiteSpace(e.Name) &&
            e.FullName.StartsWith("65x02-main/6502/v1/", StringComparison.OrdinalIgnoreCase));

        foreach (var entry in testEntries)
        {
            var path = Path.Combine(jsonTemp.FullName, entry.Name);

            Console.WriteLine($"Extracting test {entry.Name} to {path}...");

            await using var entryStream = await entry.OpenAsync(cancellationToken);
            await using var fileStream = File.Create(path);
            await entryStream.CopyToAsync(fileStream, cancellationToken);
        }
    }
}