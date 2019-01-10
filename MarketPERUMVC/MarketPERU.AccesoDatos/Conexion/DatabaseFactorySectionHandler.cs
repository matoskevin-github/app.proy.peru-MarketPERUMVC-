using System;
using System.Configuration;

namespace MarketPERU.AccesoDatos.Conexion
{
    public class DatabaseFactorySectionHandler
    {
        public string DbCnxStr { get; private set; }       

        public DatabaseFactorySectionHandler()
        {
            DbCnxStr = ConnectionString();
        }
        private string ConnectionString()
        {
            string SqlServerConnectionString = string.Empty;
            ConnectionStringSettings stringSettings = ConfigurationManager.ConnectionStrings["DbCnx"];
            if (stringSettings == null || string.IsNullOrEmpty(stringSettings.ConnectionString))
            {
                throw new Exception("Error fatal: falta la cadena de conexión en el archivo web.config");
            }
            else
            {
                SqlServerConnectionString = stringSettings.ConnectionString;
            }
            return SqlServerConnectionString;
        }
    }
}
