using NATS.Extensions.Microsoft.DependencyInjection;
using NATS.Client.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNatsClient();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/say-hello", async (INatsConnection natsConnector) => {
    await natsConnector.PublishAsync("hello", "Hello World!");
    return "Published";
});

app.Run();
