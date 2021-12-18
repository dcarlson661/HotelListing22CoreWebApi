

using HotelListing22CoreWebApi.Configurations;
using HotelListing22CoreWebApi.Data;
using HotelListing22CoreWebApi.IRepository;
using HotelListing22CoreWebApi.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;  //add in the proj file <PackageReference Include="Serilog.AspNetCore" Version="4.1.0" />
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//now configure Serilog for logging
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File(path: "C:\\SafeenvMeterPayloads\\log\\HotelListing22Logs\\log-.txt",
                  outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                  rollingInterval: RollingInterval.Day,
                  restrictedToMinimumLevel: LogEventLevel.Information
    ));


builder.Services.AddCors(o => {
    o.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

//Hello World.  This to test looking at git changes
//auto mapper from a nuget package the link provided help understanding
//https://www.pragimtech.com/blog/blazor/using-automapper-in-asp.net-core/
//MapperInitilizer.cs in in configurations look a that to see what i map
builder.Services.AddAutoMapper(typeof(MapperInitilizer));




//Transient means everytime its needed AddScopped is for a period of time
// AddSingleton is only one instance
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();


builder.Services.AddControllers().AddNewtonsoftJson(op =>
                op.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore);


//https://medium.com/executeautomation/asp-net-core-6-0-minimal-api-with-entity-framework-core-69d0c13ba9ab
var cs = builder.Configuration.GetConnectionString("sqlConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(cs)) ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

Log.Information("Application is starting");
app.Run();
