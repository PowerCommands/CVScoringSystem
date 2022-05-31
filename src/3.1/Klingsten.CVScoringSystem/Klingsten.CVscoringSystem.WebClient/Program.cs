using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Klingsten.CVscoringSystem.WebClient;
using Klingsten.CVscoringSystem.WebClient.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IScorecardService, ScorecardService>();
builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();
builder.Services.AddSingleton<IEventService, EventService>();
builder.Services.AddSingleton<IStateService, StateService>();
builder.Services.AddSingleton<IPreferencesService, PreferencesService>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();
