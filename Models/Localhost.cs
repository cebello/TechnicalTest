
using Microsoft.Data.SqlClient;

namespace TechnicalTest.Models
{
    public class Localhost : Configuration
    {
        protected SqlConnection conexion;

        public Localhost()
        {
            conexion = new SqlConnection(connectionString);
            conexion.Open();
        }

        ~Localhost()
        {
            conexion.Close();
        }
    }
}
