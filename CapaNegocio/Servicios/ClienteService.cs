using CapaDatos.DAO;
using System.Data;

namespace CapaNegocio.Servicios
{
    public class ClienteService
    {
        ClienteDAO clienteDAO = new ClienteDAO();

        public void AgregarCliente(string nombre, string correo, string telefono, string direccion)
        {
            clienteDAO.InsertarCliente(nombre, correo, telefono, direccion);
        }

        public DataTable ListarClientes()
        {
            return clienteDAO.ObtenerClientes();
        }

        public void BorrarCliente(int idCliente)
        {
            clienteDAO.EliminarCliente(idCliente);
        }
    }
}