using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FACTURACOMPRA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cod;
            string nom;
            float precio;

            cod = cmbProducto.SelectedIndex;
            nom = cmbProducto.SelectedItem.ToString();
            precio = cmbProducto.SelectedIndex;

            switch (cod)
            {
                case 0: lblCodigo.Text = "010101";break;
                case 1: lblCodigo.Text = "020202";break;
                case 2: lblCodigo.Text = "030303";break;
                default: lblCodigo.Text = "040404";break;
            }

            switch (nom)
            {
                case "Camisa": lblNombre.Text = "Camisa";break;
                case "Pantalon": lblNombre.Text = "Pantalon";break;
                case "Polera": lblNombre.Text = "Polera";break;
                default: lblNombre.Text = "Tenis";break;
            }

            switch (precio)
            {
                case 0: lblPrecio.Text = "75";break;
                case 1: lblPrecio.Text = "100";break;
                case 2: lblPrecio.Text = "80";break;
                default: lblPrecio.Text = "50";break;
            }
            cmbProducto.Focus();
           
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                MessageBox.Show("ESCOJA UN PRODUCTO");
            }
            else
            {
                DataGridViewRow file = new DataGridViewRow();
                file.CreateCells(dgvLista);

                file.Cells[0].Value = lblCodigo.Text;
                file.Cells[1].Value = lblNombre.Text;
                file.Cells[2].Value = lblPrecio.Text;
                file.Cells[3].Value = txtCantidad.Text;
                file.Cells[4].Value = (float.Parse(lblPrecio.Text) * float.Parse(txtCantidad.Text)).ToString();

                dgvLista.Rows.Add(file);

                lblCodigo.Text = lblNombre.Text = lblPrecio.Text = txtCantidad.Text = "";

                obtenerTotal();
                txtCantidad.Focus();
            }
        }

        public void obtenerTotal()
        {
            float costot = 0;
            int contador = 0;

            contador = dgvLista.RowCount;

            for (int i = 0; i < contador; i++)
            {
                costot += float.Parse(dgvLista.Rows[i].Cells[4].Value.ToString());
            }

            lblTotalPagar.Text = costot.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rppta = MessageBox.Show("¿Desea eliminar producto?",
                    "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rppta == DialogResult.Yes)
                {
                    dgvLista.Rows.Remove(dgvLista.CurrentRow);
                }
            }
            catch { }
            obtenerTotal();
        }

        private void txtEfectivo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDevolucion.Text = (float.Parse(txtEfectivo.Text) - float.Parse(lblTotalPagar.Text)).ToString();
            }
            catch { }

            if (txtEfectivo.Text == "")
            {
                lblDevolucion.Text = "";
            }
        }
    }
}
