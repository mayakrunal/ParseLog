using System.Diagnostics;
using ParseLog;
using Xunit.Extensions;
using Xunit.Extensions.Ordering;

namespace ParseLog.Tests;

public class LogsFixture : IDisposable
{
    public List<string> logs = [];

    public LogsFixture()
    {
        logs = Program.GetLogs();
    }

    public void Dispose()
    {
        //nothing to dispose
    }
}


public class Tests(LogsFixture logsFixture) : IClassFixture<LogsFixture>
{
    private readonly LogsFixture logsFixture = logsFixture;

    [Fact, Order(1)]
    public void TestLogsCount()
    {
        // make sure logs exists
        Assert.True(logsFixture.logs.Count > 0);
    }


    [Fact, Order(2)]
    public void TestUniqueIpsAddress()
    {
        int expected = 11;

        List<ParsedIP> parsedIPs = logsFixture.logs.ParseIps();

        //make sure that total unique ip addresses are 11
        Assert.Equal(expected, parsedIPs.Count);
    }

    [Fact, Order(3)]
    public void TestMostActiveIpsAddress()
    {
        string[] expectedips = ["168.41.191.40", "177.71.128.21", "50.112.00.11"];

        List<ParsedIP> parsedIPs = logsFixture.logs.ParseIps();

        //make sure tmost active ips are as expected
        Assert.Equal(expectedips, parsedIPs.Take(3).Select(x => x.Ip).ToArray());
    }

    [Fact, Order(4)]
    public void TestMostVisitedUrls()
    {
        string[] expectedurls = ["/docs/manage-websites/", "/intranet-analytics/", "http://example.net/faq/"];

        List<ParsedUrl> parsedUrls = logsFixture.logs.ParseUrls(3);

        //make sure most visited urls are as expected
        Assert.Equal(expectedurls, parsedUrls.Take(3).Select(x => x.Url).ToArray());
    }
}