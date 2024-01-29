using Autofac.Extensions.DependencyInjection;
using Inventario.API.Extensions;
using Inventario.Core.Utils;
using Inventario.Infrastructure.Mapping;
using Serilog;
using Serilog.Sinks.MSSqlServer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddUnitOfWork();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddBusinessServices();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
builder.Host.UseSerilog().UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration).WriteTo.MSSqlServer(
                    connectionString: builder.Configuration.GetConnectionString(Constants.General.CONNECTION_STRING_DATABASE_NAME),
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "logs_excepcion", AutoCreateSqlTable = true },
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error)) ;
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration[Constants.General.ALLOWED_HOST]!);
    });
});

var app = builder.Build();


app.UseSwaggerGen();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
