using MySql.Data.MySqlClient;
using System.Data;
using CapaDatos.Configuracion;

namespace CapaDatos.DAO
{
    public class ProductoDAO : Conexion
    {
        public void InsertarProducto(string nombre, string descripcion, decimal precio, int stock)
        {
            using (var cmd = new MySqlCommand("insertar_producto", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_nombre_producto", nombre);
                cmd.Parameters.AddWithValue("p_descripcion", descripcion);
                cmd.Parameters.AddWithValue("p_precio", precio);
                cmd.Parameters.AddWithValue("p_stock", stock);
                cmd.ExecuteNonQuery();
                CerrarConexion();
            }
        }

        public DataTable ObtenerProductos()
        {
            using (var cmd = new MySqlCommand("seleccionar_productos", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
                CerrarConexion();
                return tabla;
            }
        }

        public void EliminarProducto(int idProducto)
        {
            using (var cmd = new MySqlCommand("eliminar_producto", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_producto", idProducto);
                cmd.ExecuteNonQuery();
                CerrarConexion();
            }
        }
    }
}