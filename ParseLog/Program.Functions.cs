
using System.Diagnostics;
using ParseLog;

public partial class Program
{

    /// <summary>
    /// Read the logs from the given logfile or the default one and return the lines as List
    /// </summary>
    /// <param name="logfile">path of the log file</param>
    /// <returns>Lines as List of Strings</returns>
    public static List<string> GetLogs(string logfile = "resources/programming-task-example-data.log")
    {
        if (!File.Exists(logfile))
        {
            Warn($"The File: {logfile} does not exists");
            return [];
        }

        List<string> logs;

        try
        {
            logs = File.ReadLines(logfile).ToList();
        }
        catch (Exception e)
        {
            Error($"Error while reading the logs: {e.Message}");
            throw;
        }
        return logs;
    }

    /// <summary>
    /// Counts the Unique Ips and Most Active Ips and Prints them to the console
    /// </summary>
    /// <param name="logs">The logs as List of Strings</param>
    /// <param name="topmostactive">No of top most active ips</param>
    public static void CountUniqueIpsAndMostActiveIps(List<string> logs, int topmostactive = 3)
    {
        if (logs is null || logs.Count == 0)
        {
            Warn($"There are no logs available.");
            return;
        }

        try
        {
            List<ParsedIP> parsedIPs = logs.ParseIps();

            Console.WriteLine($"Number of Total Unique Address are: {parsedIPs.Count}");
            Console.WriteLine($"Most Active Ip Addresses are:");
            for (int i = 0; i < topmostactive; i++)
            {
                Console.WriteLine($"    {parsedIPs[i].Ip}");
            }
        }
        catch (Exception e)
        {
            Error($"Error while parsing the Ips: {e.Message}");
            throw;
        }
    }

    /// <summary>
    /// Parse the logs Prints the most visted urls
    /// </summary>
    /// <param name="logs">The logs as List of String</param>
    /// <param name="topmostvisited">Num of top most visited urls</param>
    public static void MostVisitedUrls(List<string> logs, int topmostvisited = 3)
    {

        if (logs is null || logs.Count == 0)
        {
            Warn($"There are no logs available.");
            return;
        }

        try
        {
            List<ParsedUrl> parsedUrls = logs.ParseUrls(topmostvisited);

            Console.WriteLine($"Most visited Urls are:");

            foreach (var x in parsedUrls)
            {
                Console.WriteLine($"    {x.Url}");
            }

        }
        catch (Exception e)
        {
            Error($"Error while parsing the Urls: {e.Message}");
            throw;
        }
    }
}
