namespace Inventario.Infrastructure.Context
{
    #region Librerias
    using AutoMapper;
    using Inventario.Core.Interfaces.Repository;
    using Inventario.Core.Utils;
    using Inventario.Infrastructure.Repositories;
    using Inventario.Infrastructure.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Inventario.Core.Entities;
    #endregion
    /// <summary>
    /// 
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Atributos y Propiedades
        private readonly EFContext _dbContext;
        #endregion

        #region Constructor
        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region Métodos y Funciones
        public IUnitOfWork GetNewInstanceUnitOfWork()
        {
            var config = new ConfigurationBuilder().AddJsonFile(Constants.General.APP_SETTIINGS_JSON_FILE_NAME).Build();
            var connectionString = config.GetConnectionString(Constants.General.CONNECTION_STRING_DATABASE_NAME);
            DbContextOptionsBuilder optionsBuilder = new();
            var options = optionsBuilder.UseSqlServer(connectionString!).Options;
            EFContext context = new(options);
            UnitOfWork unitOfWork = new(context);
            return unitOfWork;
        }

        public IMapper GetNewInstanceMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfiles()));
            IMapper mapper = config.CreateMapper();
            return mapper;
        }

        public IBaseRepository<T> BaseRepository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>(_dbContext);
        }

        public IEjemploRepository EjemploRepository()
        {
            return new EjemploRepository(_dbContext);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public IClienteRepository ClienteRepository()
        {
            return new ClienteRepository(_dbContext);
        }

        public IGarantiaRepository GarantiaRepository()
        {
            return new GarantiaRepository(_dbContext);
        }

        public IIngresoRepository IngresoRepository()
        {
            return new IngresoRepository(_dbContext);
        }

        public IProductoRepository ProductoRepository()
        {
           return new ProductoRepository(_dbContext);
        }

        public IProveedorRepository ProveedorRepository()
        {
            return new ProveedorRepository(_dbContext);
        }

        public IUsuarioRepository UsuarioRepository()
        {
            return new UsuarioRepository(_dbContext);
        }

        public IVentaRepository VentaRepository()
        {
            return new VentaRepository(_dbContext);
        }
        #endregion
    }
}
