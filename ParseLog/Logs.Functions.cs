
namespace ParseLog;

public static class Query
{

    /// <summary>
    /// Linq query to parse the Ips from the logs
    /// </summary>
    /// <param name="logs">logs from the files</param>
    /// <returns>Records of the Parsed Ips</returns>
    public static List<ParsedIP> ParseIps(this List<string> logs)
    {
        return [.. logs.Select(l => l?[..l.IndexOf('-')] ?? string.Empty)
                        .Where(l => !string.IsNullOrEmpty(l))
                        .Select(l=> l.Trim()) //Trim the ips
                        .GroupBy(ip => ip)
                        .Select(group => new ParsedIP(group.Key, group.Count()))
                        .OrderByDescending(x => x.Count)];
    }

    /// <summary>
    /// Linq query to parse the Urls from the logs
    /// </summary>
    /// <param name="logs">logs from the files</param>
    /// <returns>Records of the Parsed Urls</returns>
    public static List<ParsedUrl> ParseUrls(this List<string> logs, int topmostvisited)
    {
        return [..logs.Select(l => l?[(l.IndexOf('"') + 1)..l.IndexOfNth('"', 2)] ?? string.Empty)
                      .Where(l => !string.IsNullOrEmpty(l))
                      .Select(l =>
                      {
                          l = l.Replace("GET", ""); // Remove GET
                          l = l.Replace("HTTP/1.1", ""); // Remove HTTP 1.1
                          l = l.Trim();
                          return l;
                      })
                      .GroupBy(url => url)
                      .Select(group => new ParsedUrl(group.Key, group.Count()))
                      .OrderByDescending(x => x.Count)
                      .Take(topmostvisited)]; // Only take top most visited;
    }
}
