
Info("Reading Log File.");
List<string> logs = GetLogs();


Info("Parsing Ip Addresses");
CountUniqueIpsAndMostActiveIps(logs);

Info("Parsing Urls");
MostVisitedUrls(logs);