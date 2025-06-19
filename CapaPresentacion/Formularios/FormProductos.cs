using CapaNegocio.Servicios;
using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormProductos : Form
    {
        ProductoService productoService = new ProductoService();

        public FormProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            // Validar campos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Debe ingresar al menos Nombre y Precio.", "Campos obligatorios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertir precio y stock
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) ||
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Precio o stock inválidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            productoService.AgregarProducto(
                txtNombre.Text,
                txtDescripcion.Text,
                precio,
                stock
            );
            MessageBox.Show("Producto agregado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
            CargarProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["id_producto"].Value);
                var confirm = MessageBox.Show("¿Está seguro que desea eliminar el producto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    productoService.BorrarProducto(id);
                    MessageBox.Show("Producto eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarProductos();
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una fila para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = productoService.ListarProductos();
            dgvProductos.ClearSelection();
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.MultiSelect = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Focus();
        }
    }
}
