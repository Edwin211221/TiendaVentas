using System;
using System.Windows.Forms;

namespace CapaPresentacion.Formularios
{
    public partial class FormMenuPrincipal : Form
    {
        public FormMenuPrincipal()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes frm = new FormClientes();
            frm.ShowDialog(); // Modal, bloquea el menú hasta cerrar
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos frm = new FormProductos();
            frm.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormVentas frm = new FormVentas();
            frm.ShowDialog();
        }
    }
}
