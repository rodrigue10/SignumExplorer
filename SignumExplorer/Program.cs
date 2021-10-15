using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SignumExplorer.Context;
using SignumExplorer.Data;
using MudBlazor.Services;
using System.Linq;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore.MySql.Design;



var builder = WebApplication.CreateBuilder(args);

var maria = builder.Configuration["MariaDBSettings:Version"];
var signum = builder.Configuration.GetConnectionString("SRSConnection");
var cultures = builder.Configuration.GetSection("Cultures")
    .GetChildren().ToDictionary(x => x.Key, y => y.Value).Keys.ToArray();


var localizatonOptions = new RequestLocalizationOptions().SetDefaultCulture("en-US")
        .AddSupportedCultures(cultures)
            .AddSupportedUICultures(cultures);



// Add services to the container.
builder.Services.AddMudServices();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources/Localization");


builder.Services.AddDbContextFactory<ExplorerContext>(opt =>
        opt.UseSqlite("Data Source=SignumExplorerDB.db"));

builder.Services.AddDbContextFactory<signumContext>(opt =>
        opt.UseMySql(signum, ServerVersion.Parse(maria)));


builder.Services.AddScoped<ISignumDataService, SignumDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRequestLocalization(localizatonOptions);
app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

