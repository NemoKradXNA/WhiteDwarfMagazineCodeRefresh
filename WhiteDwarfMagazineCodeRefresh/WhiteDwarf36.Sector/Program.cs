using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WhiteDwarf.Utilities;
using WhiteDwarf.Utilities.Displays;
using WhiteDwarf.Utilities.Interfaces;
using WhiteDwarf36.Sector.Listings;

var builder = Host.CreateApplicationBuilder(args);

// Services
builder.Services.AddSingleton<IRetroDisplay, ConsoleRetroDisplay>();

// Your application / renderer classes
builder.Services.AddLogging();
builder.Services.AddSingleton<IScreen, Zx81Display>();
builder.Services.AddSingleton<IRetroDisplay, ConsoleRetroDisplay>();
builder.Services.AddSingleton<SectorListing>();

using var host = builder.Build();

var app = host.Services.GetRequiredService<SectorListing>();

await app.Run();