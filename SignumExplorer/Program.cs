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


builder.Services.AddDbContextFactory<ExplorerContext>(opt =>
        opt.UseMySql(explorer, ServerVersion.Parse(maria)));

//builder.Services.AddDbContextFactory<signumContext>();
builder.Services.AddDbContextFactory<signumContext>(opt =>
        opt.UseMySql(signum, ServerVersion.Parse(maria)));


builder.Services.AddScoped<ISignumDataService, SignumDataService>();




var app = builder.Build();


UpdateDatabase(app);




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
