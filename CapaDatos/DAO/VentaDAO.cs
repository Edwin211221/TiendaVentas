using MySql.Data.MySqlClient;
using System.Data;
using CapaDatos.Configuracion;

namespace CapaDatos.DAO
{
    public class VentaDAO : Conexion
    {
        public void InsertarVenta(int idCliente, int idProducto, int cantidad)
        {
            using (var cmd = new MySqlCommand("insertar_venta", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_cliente", idCliente);
                cmd.Parameters.AddWithValue("p_id_producto", idProducto);
                cmd.Parameters.AddWithValue("p_cantidad", cantidad);
                cmd.ExecuteNonQuery();
                CerrarConexion();
            }
        }

        public DataTable ObtenerVentas()
        {
            using (var cmd = new MySqlCommand("seleccionar_ventas", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                DataTable tabla = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(tabla);
                CerrarConexion();
                return tabla;
            }
        }

        public void EliminarVenta(int idVenta)
        {
            using (var cmd = new MySqlCommand("eliminar_venta", AbrirConexion()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_id_venta", idVenta);
                cmd.ExecuteNonQuery();
                CerrarConexion();
            }
        }
    }
}
