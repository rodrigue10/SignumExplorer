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
using System.Net.Http.Headers;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

var maria = builder.Configuration["MariaDBSettings:Version"];
var signum = builder.Configuration.GetConnectionString("SRSConnection");
var explorer = builder.Configuration.GetConnectionString("ExplorerConnection");
var cultures = builder.Configuration.GetSection("Cultures")
    .GetChildren().ToDictionary(x => x.Key, y => y.Value).Keys.ToArray();


var localizatonOptions = new RequestLocalizationOptions().SetDefaultCulture("en-US")
        .AddSupportedCultures(cultures)
            .AddSupportedUICultures(cultures);


builder.Logging.Services.AddLogging();

// Add services to the container.
builder.Services.AddMudServices();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources/Localization");
builder.Services.AddSyncfusionBlazor();

builder.Services.AddDbContextFactory<ExplorerContext>(opt =>
        opt.UseMySql(explorer, ServerVersion.Parse(maria)));

//builder.Services.AddDbContextFactory<signumContext>();
builder.Services.AddDbContextFactory<signumContext>(opt =>
        opt.UseMySql(signum, ServerVersion.Parse(maria)));


builder.Services.AddScoped<ISignumDataService, SignumDataService>();
builder.Services.AddHttpClient<ISignumAPIService, SignumAPIService>();   


var app = builder.Build();


UpdateDatabase(app);

//Register Syncfusion license
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI2NDUzQDMxMzkyZTMzMmUzMEJQeTJVNm81aXRQeE5UNkdwZHVCbVNGRkVDWlNzS2RLUkVvaDZIMjZrYWc9;NTI2NDU0QDMxMzkyZTMzMmUzMFRmTSsvSGZyTWtQUDVORVlueXdIMVo0bmk5OGMxWmIzTVhsWmdrL3J2ckk9;NTI2NDU1QDMxMzkyZTMzMmUzMFU3NWlLeVg4WmpzNWtITXVWZ2dlaHRJYWxSdFgyL3Y2bVhyUjJoMDVLUkE9;NTI2NDU2QDMxMzkyZTMzMmUzMEdVaFBRVXFlNFhzWGVpVG1rbHFScGw5TWhGRzFSOGdJS3M3YmpXRUxVOFk9;NTI2NDU3QDMxMzkyZTMzMmUzMFZGTlFzaG9zMkMvblFPQk9HWkx3bllkdHR2TzhVR1NNTkd0VitVQWtKWms9;NTI2NDU4QDMxMzkyZTMzMmUzMFg5cFdNR1BEc2F0YTE1TDNSOHJsSXpXQzV3dmxZVUkwY245Z1hkWkRhTXc9;NTI2NDU5QDMxMzkyZTMzMmUzMG9HekJpNUlDYm5NOVpvaTdlbkp5YjB3U3VCVmwyaFZ6U3J6R1hndkZtTG89;NTI2NDYwQDMxMzkyZTMzMmUzMFE5U09RWnVwL2htMkxmZ2FSUTNjTnVGbzBLTWF5ME5SaXdsWDhpcXUrRHM9;NTI2NDYxQDMxMzkyZTMzMmUzMFYxdHdNclg0YWNhdnV1bENjeWowU2U4eTR0ZDJWUGtpK1J4anIxUm4yN0E9;NTI2NDYyQDMxMzkyZTMzMmUzMG9oN0l6c056MGRqTWdSTXVraVpXT2ZhMWJtYU9sMVJMSXlRWU52K3JRa2c9;NTI2NDYzQDMxMzkyZTMzMmUzMG85MURwaWo5b2FFdHpOYldwWmM3bjF6OEpuMXFKOXZld2djRnZFSDJZeTg9");




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

 static void UpdateDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices
        .GetRequiredService<IServiceScopeFactory>()
        .CreateScope())
    {
        using (var context = serviceScope.ServiceProvider.GetService<signumContext>())
        {
            context.Database.SetCommandTimeout(90);

            //Clean out EF Migrations history.  This will help make the migration always run on startup.
            //Assumptions is that i'm only going to manage 1 custom migration file that includes the necessary SQL scripts for additions.
            //
            //context.Database.ExecuteSqlRaw(@"DROP TABLE signum.`__EFMigrationsHistory`;");

            context.Database.Migrate();
                        
            //Maybe Remove after migration done?
           // context.Database.ExecuteSqlRaw(@"DROP TABLE signum.`__EFMigrationsHistory`;");

        }
        using (var expcontext = serviceScope.ServiceProvider.GetService<ExplorerContext>())
        {
            expcontext.Database.SetCommandTimeout(90);


            expcontext.Database.Migrate();


        }
    }
}
