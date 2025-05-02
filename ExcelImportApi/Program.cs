using ExcelImportApi.Data;
using ExcelImportApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the Excel import service
builder.Services.AddScoped<IExcelImportService, ExcelImportService>();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Enable Swagger only in Development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS redirection and request pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Map attribute-routed controllers

app.Run();
