
namespace Inventario.Infrastructure.Context
{
    #region Librerias
    using Microsoft.EntityFrameworkCore;
    #endregion
    public partial class EFContext : DbContext
    {

        public EFContext(DbContextOptions options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}