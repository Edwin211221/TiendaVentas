using CapaDatos.DAO;
using System.Data;

namespace CapaNegocio.Servicios
{
    public class ProductoService
    {
        ProductoDAO productoDAO = new ProductoDAO();

        public void AgregarProducto(string nombre, string descripcion, decimal precio, int stock)
        {
            productoDAO.InsertarProducto(nombre, descripcion, precio, stock);
        }

        public DataTable ListarProductos()
        {
            return productoDAO.ObtenerProductos();
        }

        public void BorrarProducto(int idProducto)
        {
            productoDAO.EliminarProducto(idProducto);
        }
    }
}