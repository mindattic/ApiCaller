# ApiCaller

Windows Forms load-test harness that fires thousands of throttled, concurrent GET requests at a REST endpoint from a CSV of numeric IDs and reports hits, misses and projected throughput.

![C#](https://img.shields.io/badge/C%23-WinForms-512BD4) ![.NET](https://img.shields.io/badge/.NET-6.0--windows-512BD4) ![Platform](https://img.shields.io/badge/platform-Windows-0078D6) ![Status](https://img.shields.io/badge/status-prototype-orange)

```text
 +---------------------------- APICaller ----------------------------+
 |  CSV File   [ test1.csv                              ] [Open...]  |
 |  Base URL   [ https://api.example.org/items/         ]            |
 |  Thread Count [200]  Ping Rate [200]  Task Delay [1]  [x] Preview |
 |                                                         [  GET  ] |
 |  +-------------------- CSV preview grid ------------------------+ |
 |  | Col0  | Col1  | Col2  | ...                                  | |
 |  +--------------------------------------------------------------+ |
 +-------------------------------------------------------------------+
        |
        v  console window (allocated by the app) streams progress
```

A private prototype from early 2023. There is no hosted build; run it from source.

## Why

- Find out how fast an ID-addressed API really answers before you commit to a bulk job against it.
- Tune concurrency and per-request delay from the form, without recompiling, to stay inside a rate limit.
- See every ID that resolved and every ID that failed, sorted, so you can retry only the gaps.
- Get rough per-minute and per-hour throughput projections from a short sample run.

## Features

- Loads any comma-separated file and pulls every positive integer out of every cell as an ID to request.
- Optional grid preview of the loaded CSV and a count of cells in the table.
- Sends `GET {Base URL}{id}` for each ID through a shared `HttpClient`, with a `SemaphoreSlim` capping concurrent requests at the Thread Count value.
- Waits Task Delay milliseconds after each successful request to respect a rate limit.
- Prints a progress line every Ping Rate completed requests.
- Deserializes each JSON response into a typed model and logs the record title on success; counts 404, 400 and exceptions separately.
- At the end prints successes and failures ordered by ID, the total elapsed time, throughput projections, and a comma-separated list of every ID that succeeded.

## Quick start

Prerequisites: Windows and the .NET 6 SDK (or Visual Studio 2022).

```powershell
git clone https://github.com/mindattic/ApiCaller.git
cd ApiCaller
dotnet run --project APICaller\APICaller.csproj
```

1. Click Open... and choose `APICaller\test1.csv` or `APICaller\test2.csv`.
2. Check the Base URL (the ID is appended directly, so keep the trailing slash).
3. Set Thread Count, Ping Rate and Task Delay, then click GET.
4. Watch the console window that opens next to the form.

## Usage

### Options

| Field | Default | Meaning |
| --- | --- | --- |
| CSV File | developer path | File of IDs. Every cell that parses as an integer greater than zero becomes one request. |
| Base URL | a public, keyless museum-collection artworks endpoint | Prefix for every request; the ID is appended as-is. |
| Thread Count | 200 | Maximum requests in flight at once (falls back to 3 if not a number). |
| Ping Rate | 200 | Print a progress line every N completed requests; 0 turns it off (falls back to 200). |
| Task Delay | 1 | Milliseconds each worker waits after a successful request (falls back to 1). |
| Preview CSV | on | Bind the loaded table to the grid. |

### Input files

`test1.csv` (48 lines) and `test2.csv` (101 lines) are sample ID lists: rows of comma-separated integers with no header row. The reader treats the first row as data, so any CSV of IDs works.

### Output

Everything goes to the console window the app allocates on start. The shape, taken from the format strings in `frmMain.cs`:

```text
00:00:00     Starting...
00:00:04     200 requests completed in 00:00:04
00:00:09     400 requests completed in 00:00:09

00:00:12     Done.

ID: 11510     Title: <record title>
ID: 12123     Title: <record title>
INFO:     612 requests completed in 00:00:12
Request failed: ID: 13242     NotFound
INFO:     3,060 requests completed per minute
INFO:     183,600 requests completed in 1 hour
...
11510,12123,15476,...
```

## How it works

```text
CSV file --ReadCSV--> DataTable --ParseDataTable--> List<int> IDs
                                                       |
                         SemaphoreSlim(Thread Count)   v
             +-----------------------------------------------------+
             |  Task.Run per ID:                                   |
             |    GET Base URL + id   (static HttpClient)          |
             |    404 / 400 / exception -> Statistics + error log  |
             |    200 -> Newtonsoft.Json -> ArcticResponse -> title|
             |    every Ping Rate -> progress line                 |
             |    Task.Delay(Task Delay)                           |
             +-----------------------------------------------------+
                                   |
                         Task.WhenAll -> PrintResults
```

The response model in `Models/ArcticResponse.cs` matches a public artworks API's JSON shape (`data`, `info`, `config`). Only `data.title` is read; point the tool at a different API and you will need a matching model.

## Project layout

| Path | Purpose |
| --- | --- |
| `APICaller/APICaller.sln` | Visual Studio solution |
| `APICaller/APICaller.csproj` | WinExe, `net6.0-windows`, Windows Forms; Newtonsoft.Json 13, Microsoft.Extensions.Http 7, Microsoft.AspNet.WebApi.Client 5.2 |
| `APICaller/frmMain.cs` | Form events, request loop, throttling and console reporting |
| `APICaller/ReadCSV.cs` | CSV to `DataTable` via `TextFieldParser` |
| `APICaller/Statistics.cs` | Thread-safe success, 404, 400 and exception counters |
| `APICaller/Models/Logger.cs` | Concurrent log of success and error lines keyed by ID |
| `APICaller/Models/ArcticResponse.cs` | JSON response model |
| `APICaller/Extensions/` | `string.Repeat` and `List.ChunkBy` helpers |
| `APICaller/FileWriter.cs` | Simple file writer (not wired up) |
| `APICaller/test1.csv`, `APICaller/test2.csv` | Sample ID lists |
| `APICaller/Commit.cmd` | Stage, commit with a timestamp message, and push |

## Limitations

- On load the form opens the CSV path baked into `frmMain.Designer.cs`, which points at the original developer machine; change that default (or clear it) before running elsewhere.
- Results only go to the console. `results.csv` is empty and `FileWriter` is not called.
- The `Statistics` counters are collected but never printed.
- Throughput projections only print when the run takes between 1 and 59 seconds, and use whole seconds.
- Previewing a very wide CSV can hit the WinForms grid limit noted as a TODO in `OpenFile` (column FillWeight sum over 65535); untick Preview CSV for large files.
- No tests.

## Documentation

There are no separate docs; this README and the source are the reference. The sibling tools [APIConsole](https://github.com/mindattic/APIConsole) and [USPSAddressValidator](https://github.com/mindattic/USPSAddressValidator) reuse the same throttled request loop.

## License

No license file. All rights reserved.

Part of [MindAttic](https://mindattic.com) — see more projects at [github.com/mindattic](https://github.com/mindattic). Related: [APIConsole](https://github.com/mindattic/APIConsole), [USPSAddressValidator](https://github.com/mindattic/USPSAddressValidator).
