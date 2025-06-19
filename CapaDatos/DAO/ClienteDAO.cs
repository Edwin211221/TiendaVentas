using MySql.Data.MySqlClient;
using System.Data;
using CapaDatos.Configuracion;

namespace CapaDatos.DAO
{
    public class ClienteDAO : Conexion
    {
        public void InsertarCliente(string nombre, string correo, string telefono, string direccion)
        {
            using (var cmd = new MySqlCommand("insertar_cliente", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre", nombre);
                cmd.Parameters.AddWithValue("p_correo", correo);
                cmd.Parameters.AddWithValue("p_telefono", telefono);
                cmd.Parameters.AddWithValue("p_direccion", direccion);
                cmd.ExecuteNonQuery();
                CerrarConexion();
            }
        }

        public DataTable ObtenerClientes()
        {
            using (var cmd = new MySqlCommand("seleccionar_clientes", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
                CerrarConexion();
                return tabla;
            }
        }

        public void EliminarCliente(int idCliente)
        {
            using (var cmd = new MySqlCommand("eliminar_cliente", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_cliente", idCliente);
                cmd.ExecuteNonQuery();
                CerrarConexion();
            }
        }
    }
}