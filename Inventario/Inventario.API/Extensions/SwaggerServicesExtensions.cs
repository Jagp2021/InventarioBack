namespace Inventario.API.Extensions
{
    using Microsoft.OpenApi.Any;
    #region Librerias
    using Microsoft.OpenApi.Models;
    #endregion
    /// <summary>
    /// Fecha: 24 de Febrero de 2023
    /// Descripción: Clase que define la documentación de Swagger
    /// Autor: Javier Gonzalez
    /// </summary>
    public static class SwaggerServicesExtensions
    {
        #region Métodos y Funciones
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.MapType<TimeSpan>(() => new OpenApiSchema
                {
                    Type = "string",
                    Example = new OpenApiString("00:00:00")
                });
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Inventario",
                    Version = "v1",
                    Description = "Servicios de Aplicación de Inventarios"
                });
            });
            return services;
        }

        public static IApplicationBuilder UseSwaggerGen(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("./v1/swagger.json", "API v1"));
            return app;
        }
        #endregion
    }

}
