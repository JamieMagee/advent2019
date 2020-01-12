using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdventOfCode.Blazor.Services
{
  public interface IInputHandler
  {
    bool IsCachedInputAvailable(int year, int day);

    Task<string> GetInputAsync(int year, int day);

    Task<string> GetDescriptionAsync(int year, int day);

    Task<string> GetSourceCodeAsync(int year, int day);

    object[] GetResults(int year, int day);

    void ClearResults(int year, int day);
  }

  public sealed class InputHandler : IInputHandler
  {
    public InputHandler(HttpClient httpClient)
    {
      myHttpClient = httpClient;
    }

    public bool IsCachedInputAvailable(int year, int day) => myInputCache.ContainsKey((year, day));

    public async Task<string> GetInputAsync(int year, int day)
    {
      var input = await GetFileAsync(year, day, "input/{0}/day{1}.txt", myInputCache);
      return input;
    }

    public async Task<string> GetDescriptionAsync(int year, int day)
    {
      var description = await GetFileAsync(year, day, "description/{0}/day{1}.html", myDescriptionCache);
      return description ?? "No description available.";
    }

    public async Task<string> GetSourceCodeAsync(int year, int day)
    {
      var source = await GetFileAsync(year, day, "source/{0}/Day{1}.cs", mySourceCodeCache);
      return source ?? "No source file available.";
    }

    public async Task<string> GetFileAsync(int year, int day, string pathTemplate, IDictionary<ValueTuple<int, int>, string> cache)
    {
      if (!cache.TryGetValue((year, day), out var description))
      {
        var dayString = day.ToString().PadLeft(2, '0');
        try
        {
          description = await myHttpClient.GetStringAsync(string.Format(pathTemplate, year, dayString));
        }
        catch (HttpRequestException)
        {
          return null;
        }
        cache.Add((year, day), description);
      }

      return description;
    }

    public object[] GetResults(int year, int day)
    {
      if (!myResultCache.TryGetValue((year, day), out var results))
      {
        results = new object[2];
        myResultCache.Add((year, day), results);
      }
      return results;
    }

    public void ClearResults(int year, int day)
    {
      var results = GetResults(year, day);
      for (var i = 0; i < results.Length; i++)
      {
        results[i] = null;
      }
    }

    private readonly HttpClient myHttpClient;
    private readonly Dictionary<ValueTuple<int, int>, object[]> myResultCache = new Dictionary<ValueTuple<int, int>, object[]>();
    private readonly Dictionary<ValueTuple<int, int>, string> myInputCache = new Dictionary<ValueTuple<int, int>, string>();
    private readonly Dictionary<ValueTuple<int, int>, string> myDescriptionCache = new Dictionary<ValueTuple<int, int>, string>();
    private readonly Dictionary<ValueTuple<int, int>, string> mySourceCodeCache = new Dictionary<ValueTuple<int, int>, string>();
  }
}