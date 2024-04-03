# .Net 8 Console Application to parse logs and view required information

## Task

The task is to parse a log file containing HTTP requests and to report on its contents.

For a given log file The application will show following

- The number of unique IP addresses
- The top 3 most visited URLs
- The top 3 most active IP addresses

### Pre-Requisite for build

- [dotnet-runtime-8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [dotnet-sdk-8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)

### Build & Run Project

```sh
#from Solution Directory
cd ParseLog # go to project folder
dotnet restore # download the packages if required
dotnet build # build the project
dotnet run # run the project
```

### Build & Run UnitTests

```sh
#from Solution Directory
cd ParseLog.Tests # go to project folder
dotnet restore # download the packages if required
dotnet build # build the project
dotnet test # run the project
```
