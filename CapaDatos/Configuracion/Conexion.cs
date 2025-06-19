using MySql.Data.MySqlClient;

namespace CapaDatos.Configuracion
{
    public class Conexion
    {
        private readonly string cadenaConexion = "Server=localhost;Database=tienda_poo2;Uid=root;Pwd=;";
        protected MySqlConnection conexion;

        public MySqlConnection AbrirConexion()
        {
            conexion = new MySqlConnection(cadenaConexion);
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}