using CapaNegocio.Servicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormVentas : Form
    {
        VentaService ventaService = new VentaService();
        ProductoService productoService = new ProductoService();
        ClienteService clienteService = new ClienteService();

        public FormVentas()
        {
            InitializeComponent();
            CargarCombos();
            CargarVentas();
        }

        private void CargarCombos()
        {
            // Cargar clientes
            cbClientes.DataSource = clienteService.ListarClientes();
            cbClientes.DisplayMember = "nombre";
            cbClientes.ValueMember = "id_cliente";

            // Cargar productos
            cbProductos.DataSource = productoService.ListarProductos();
            cbProductos.DisplayMember = "nombre_producto";
            cbProductos.ValueMember = "id_producto";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedIndex < 0 || cbProductos.SelectedIndex < 0 || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Complete todos los campos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Cantidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idCliente = Convert.ToInt32(cbClientes.SelectedValue);
            int idProducto = Convert.ToInt32(cbProductos.SelectedValue);

            ventaService.AgregarVenta(idCliente, idProducto, cantidad);
            MessageBox.Show("Venta registrada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarVentas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["id_venta"].Value);
                var confirm = MessageBox.Show("¿Está seguro que desea eliminar la venta seleccionada?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    ventaService.BorrarVenta(id);
                    MessageBox.Show("Venta eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarVentas();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarVentas()
        {
            dgvVentas.DataSource = ventaService.ListarVentas();
            dgvVentas.ClearSelection();
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.MultiSelect = false;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LimpiarCampos()
        {
            cbClientes.SelectedIndex = -1;
            cbProductos.SelectedIndex = -1;
            txtCantidad.Clear();
        }
    }
}