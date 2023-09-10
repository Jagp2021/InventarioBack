namespace Inventario.Core.Interfaces.Service
{
    #region Librerias
    using Inventario.Core.Dtos;
    #endregion
    /// <summary>
    /// Fecha: 01 de Septiembre de 2023
    /// Descripción: Interfaz que define la estructura para el servicio Ejemplo
    /// Autor: Asesoftware - Javier Gonzalez
    /// </summary>
    public interface IEjemploService
    {
        EjemploDto MetodoEjemplo(bool estado);
    }
}
