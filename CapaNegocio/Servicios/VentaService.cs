using CapaDatos.DAO;
using System.Data;

namespace CapaNegocio.Servicios
{
    public class VentaService
    {
        VentaDAO ventaDAO = new VentaDAO();

        public void AgregarVenta(int idCliente, int idProducto, int cantidad)
        {
            ventaDAO.InsertarVenta(idCliente, idProducto, cantidad);
        }

        public DataTable ListarVentas()
        {
            return ventaDAO.ObtenerVentas();
        }

        public void BorrarVenta(int idVenta)
        {
            ventaDAO.EliminarVenta(idVenta);
        }
    }
}
