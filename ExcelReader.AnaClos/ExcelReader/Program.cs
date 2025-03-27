using ExcelReader.Controllers;
using ExcelReader.Data;
using ExcelReader.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

bool writeExcel = false;

System.Globalization.CultureInfo.CurrentCulture = new System.Globalization.CultureInfo("en-US");
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
string connectionString = builder.Configuration.GetConnectionString("ExcelConnection");
string excelFile = builder.Configuration["File:FileName"];

builder.Services.AddSingleton<ExcelService>();
builder.Services.AddSingleton(sp => new ExcelService(excelFile));
builder.Services.AddSingleton<DataBaseService>();
builder.Services.AddSingleton<ExcelController>();
builder.Services.AddDbContext<ExcelDbContext>(options =>
    options.UseSqlServer(connectionString));

using IHost host = builder.Build();
using (var scope = host.Services.CreateScope())
{
    var controller = new ExcelController(
        scope.ServiceProvider.GetRequiredService<ExcelService>(),
        scope.ServiceProvider.GetRequiredService<DataBaseService>()
    );

    controller.WriteDatabaseFromExcel(writeExcel);
}
host.Run();