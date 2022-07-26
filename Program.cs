using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Steeltoe.Management.Endpoint;
using BlazorApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
// Add services to the container.
// Steeltoe actuators
// builder.AddHealthActuator();
// builder.AddInfoActuator();
builder.AddAllActuators();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
