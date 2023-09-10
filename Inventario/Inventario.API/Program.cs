using Autofac.Extensions.DependencyInjection;
using Inventario.API.Extensions;
using Inventario.Core.Utils;
using Inventario.Infrastructure.Mapping;
using Serilog;


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
                    .ReadFrom.Configuration(hostingContext.Configuration));
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
