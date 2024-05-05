namespace Inventario.Core.Utils
{
    /// <summary>
    /// Constantes del Proyecto
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Constantes Generales del Proyecto
        /// </summary>
        public static class General
        {
            public const string APP_SETTIINGS_JSON_FILE_NAME = "appsettings.json";
            public const string CONNECTION_STRING_DATABASE_NAME = "DefaultConnection";
            public const string CADENA_VACIA = "";
            public const string EXREG_ALFANUM_NOESPECIALES = @"^(?! )(?!.* $)[A-Za-z0-9áéíóúÁÉÍÓÚñÑ\s.""-]+$";
            public const string MENSAJE_GENERICO = "Ocurrió un error realizando la transacción. Consulte con el administrador o intentelo nuevamente";
            public const string ALLOWED_HOST = "AllowedHosts";
            public const string CONTENT_TYPE = "";
            public const string ACCION_GUARDAR = "Guardar";
            public const string ACCION_ACTUALIZAR = "Actualizar";
        }

        /// <summary>
        /// Constantes de Dominios
        /// </summary>
        public static class Dominio
        {
            public const string DOMINIO_TIPO_DOCUMENTO = "TIPODOCUMENTO";
            public const string DOMINIO_TIPO_PAGO = "TIPOPAGO";
            public const string DOMINIO_ESTADO_GARANTIA = "ESTADOGARANTIA";
            public const string DOMINIO_TIPO_PRODUCTO = "TIPOPRODUCTO";
            public const string DOMINIO_TIPO_GARANTIA = "TIPOGARANTIA";
            public static class TipoDocumento
            {
                public const string CC = "CC";
                public const string CE = "CE";
                public const string NIT = "NIT";
            }

            public static class EstadoGarantia
            {
                public const string REGISTRADA = "REGI";
                public const string GESTIONADA = "GEST";
                public const string CERRADA = "CERR";
            }
        }

        



    }
}
