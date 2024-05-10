using Microsoft.AspNetCore.Authentication;
using System.Data.SqlClient;

namespace CRUDCoreMVC.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;

        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string GetCadenaSQl()
        {
            return cadenaSQL;
        }
    }
}
