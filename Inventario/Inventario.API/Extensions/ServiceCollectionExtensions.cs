namespace Inventario.API.Extensions
{
    #region Librerias
    using Inventario.Core.Interfaces.Repository;
    using Inventario.Core.Interfaces.Service;
    using Inventario.Core.Services;
    using Inventario.Core.Utils;
    using Inventario.Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;
    #endregion

    /// <summary>
    /// Fecha: 24 de Febrero de 2023
    /// Descripción:Clase que define la inyección de dependencias de servicios
    /// Autor: Javier Gonzalez
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        #region Métodos y Funciones
        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la inyección de dependencias para el arupador de repositorios
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return services
                .AddScoped<IUnitOfWork, UnitOfWork>();
        }

        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la inyección de dependencias para la conexión a base de datos
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services
            , IConfiguration configuration)
        {
            return services.AddDbContext<EFContext>(options =>
                     options.UseSqlServer(configuration.GetConnectionString(Constants.General.CONNECTION_STRING_DATABASE_NAME))
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }

        /// <summary>
        /// Fecha: 24 de Febrero de 2023
        /// Descripción: Método que define la inyección de dependencias para los servicios de Core
        /// Autor: Javier Gonzalez
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IClienteService, ClienteService>();
            services.AddTransient<IGarantiaService, GarantiaService>();
            services.AddTransient<IIngresoService, IngresoService>();
            services.AddTransient<IProductoService, ProductoService>();
            services.AddTransient<IProveedorService, ProveedorService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IVentaService, VentaService>();
            services.AddTransient<IDominioService, DominioService>();
            services.AddTransient<IPermisosService, PermisosService>();

            return services;
        }
        #endregion
    }
}
