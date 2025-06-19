using CapaNegocio.Servicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormClientes : Form
    {
        ClienteService clienteService = new ClienteService();

        public FormClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar al menos Nombre y Correo.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clienteService.AgregarCliente(
                txtNombre.Text,
                txtCorreo.Text,
                txtTelefono.Text,
                txtDireccion.Text
            );
            MessageBox.Show("Cliente agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarClientes();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["id_cliente"].Value);
                var confirm = MessageBox.Show("¿Está seguro que desea eliminar el cliente seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    clienteService.BorrarCliente(id);
                    MessageBox.Show("Cliente eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarClientes();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = clienteService.ListarClientes();
            dgvClientes.ClearSelection();
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtNombre.Focus();
        }
    }
}