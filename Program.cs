using System.Text.Json.Serialization;
using TrucksAPI.Helpers;
using TrucksAPI.Repositories;
using TrucksAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    var services = builder.Services;

    services.AddCors();
    services.AddControllers().AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    services.AddSingleton<DataContext>();
    services.AddScoped<ITruckRepository, TruckRepository>();
    services.AddScoped<ITruckService, TruckService>();

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}


var app = builder.Build();

// Populate database with random data
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Init();
}

// Configure the HTTP request pipeline.
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();

    app.UseCors(c => c
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.MapControllers();
}

app.Run();
