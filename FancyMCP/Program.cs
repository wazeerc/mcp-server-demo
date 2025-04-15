using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MonkeyMCP;

var builder = Host.CreateApplicationBuilder(args);
builder.Logging.AddConsole(consoleLogOptions =>
{
  consoleLogOptions.LogToStandardErrorThreshold = LogLevel.Trace;
});
builder.Services.AddHttpClient();
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();
builder.Services.AddSingleton<MonkeyService>();
await builder.Build().RunAsync();