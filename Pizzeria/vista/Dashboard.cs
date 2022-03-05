using Pizzeria.metodos;
using Pizzeria.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    public partial class Dashboard : Form
    {
        SucursalesCRUD sucursales = new SucursalesCRUD();
        PlatiilosCRUD platillos = new PlatiilosCRUD();
        MetodoPedidos pedidos = new MetodoPedidos();
       
        public Dashboard()
        {
            InitializeComponent();
            
            cbSucursales.DataSource= sucursales.retornarNombreSucursales();
            cbPlatillos.DataSource = platillos.retornarNombrePlatillos();
           
            dgvSucursales.DataSource = sucursales.MostrarSucursales();
            dgvMenu.DataSource = platillos.MostrarMenu();
            dgvPedidos.DataSource = pedidos.retornarMisPedidos();


            lbSucursalesDashboard.Text = " Sucursales: "+sucursales.longitudSucursales();
            lbPlatillos.Text = " Platillos: " + platillos.longitudPlatillos();
            lbPedidos.Text = " Pedidos: " + pedidos.longitudPedidos();
        }
        //instancias de los metodos CRUD
        SucursalesCRUD sCRUD = new SucursalesCRUD();
        PlatiilosCRUD pCRUD = new PlatiilosCRUD();
        private void tabPage1_Click(object sender, EventArgs e)
        {
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregarSucursal_Click(object sender, EventArgs e)

        {
            sCRUD.guardarSucursalNueva(txtNombre.Text, txtDireccion.Text, txtTelefono.Text, dgvSucursales,validarSucursales,txtNombre,txtDireccion,txtTelefono);
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //para que admita tecla de espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            /*verifica que pueda ingresar punto y también que solo pueda
           ingresar un punto*/
            else if ((e.KeyChar == '.') && (!txtTelefono.Text.Contains(".")))
            {
                e.Handled = false;
            }
            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de números", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnVer_Click(object sender, EventArgs e)
        {

        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceSeleccionado = Int32.Parse(dgvSucursales.CurrentRow.Index.ToString());
                sCRUD.eliminarUnaSucursal(indiceSeleccionado);
                MessageBox.Show("Eliminado","Eliminado",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dgvSucursales.DataSource = null;
                dgvSucursales.DataSource = sCRUD.ListaSucursal;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }



        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        public static String nombreNuevo;
        public static String direccionNueva;
        public static String telefonoNuevo;
        public static String id;

        public static String nombreMenuNuevo;
        public static String descripcionMenuNueva;
        public static String precioMenuNuevo;
        public static String idMenu;

        private void dgvSucursales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nombreNuevo = dgvSucursales.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            direccionNueva = dgvSucursales.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
            telefonoNuevo = dgvSucursales.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
            id = dgvSucursales.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            
            int indiceSeleccionado = Int32.Parse(dgvSucursales.CurrentRow.Index.ToString());
            sCRUD.modificarSucursal(indiceSeleccionado, txtNombre.Text, txtDireccion.Text, txtTelefono.Text, id,validarSucursales,
                txtNombre,txtDireccion,txtTelefono);
            dgvSucursales.DataSource = null;
            dgvSucursales.DataSource = sCRUD.ListaSucursal;
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtNombre.Clear();
            btnAgregarSucursal.Enabled = true;

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                btnAgregarSucursal.Enabled = false;
                if (nombreNuevo == "")
                {
                    MessageBox.Show("Seleccione una fila a editar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtNombre.Text = nombreNuevo;
                    txtDireccion.Text = direccionNueva;
                    txtTelefono.Text = telefonoNuevo;

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pCRUD.guardarPlatilloNuevo(txtNombreMenu.Text, txtPrecioPlatillo.Text, txtDescripcionPlatillo.Text, dgvMenu,
                validarPlatillos,txtNombreMenu,txtPrecioPlatillo,txtDescripcionPlatillo);
            txtNombreMenu.Clear();
            txtPrecioPlatillo.Clear();
            txtDescripcionPlatillo.Clear();
        }

        private void btnEliminarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceSeleccionado = Int32.Parse(dgvMenu.CurrentRow.Index.ToString());
                pCRUD.eliminarUnPlatillo(indiceSeleccionado);
                MessageBox.Show("Eliminado", "Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvMenu.DataSource = null;
                dgvMenu.DataSource = pCRUD.Menu;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void btnSeleccionarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                btnAgregarMenu.Enabled = false;
                if (nombreMenuNuevo == "")
                {
                    MessageBox.Show("Seleccione una fila a editar", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtNombreMenu.Text = nombreMenuNuevo;
                    txtDescripcionPlatillo.Text = descripcionMenuNueva;
                    txtPrecioPlatillo.Text = precioMenuNuevo;

                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nombreMenuNuevo = dgvMenu.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            descripcionMenuNueva = dgvMenu.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
            precioMenuNuevo = dgvMenu.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
            idMenu = dgvMenu.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
        }

        private void btnModificarMenu_Click(object sender, EventArgs e)
        {
            int indiceSeleccionado = Int32.Parse(dgvMenu.CurrentRow.Index.ToString());
            pCRUD.modificarPlatillo(indiceSeleccionado, idMenu, txtNombreMenu.Text, txtPrecioPlatillo.Text, txtDescripcionPlatillo.Text,
                validarPlatillos,txtNombreMenu,txtPrecioPlatillo,txtDescripcionPlatillo);
            dgvMenu.DataSource = null;
            dgvMenu.DataSource = pCRUD.Menu;
            txtNombreMenu.Clear();
            txtDescripcionPlatillo.Clear();
            txtPrecioPlatillo.Clear();
            btnAgregarMenu.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarMenuPedidos_Click(object sender, EventArgs e)
        {
            
        }

        private void lbSucursalesDashboard_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        List<Pedido> MiListaPedidos = new List<Pedido>();
        private void btnAgregarAlPedido_Click(object sender, EventArgs e)
        {
            String cbSucursal = cbSucursales.SelectedValue.ToString();
            String cbPlatillo = cbPlatillos.SelectedValue.ToString();
            if (txtNombreCliente.Text == "")
            {
                validarPedidos.SetError(txtNombreCliente, "campo obligatorio");
            }
            else
            {
                validarPedidos.Clear();
                pedidos.agregarNuevoPedido(cliente.Text, cbSucursal, cbPlatillo, dgvPedidos);
                txtNombreCliente.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreMenu_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            //para backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            //para que admita tecla de espacio
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            //si no cumple nada de lo anterior que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten letras", "validación de texto",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtPrecioPlatillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //condicion para solo números
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            //para tecla backspace
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            /*verifica que pueda ingresar punto y también que solo pueda
           ingresar un punto*/
            else if ((e.KeyChar == '.') && (!txtTelefono.Text.Contains(".")))
            {
                e.Handled = false;
            }
            //si no se cumple nada de lo anterior entonces que no lo deje pasar
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo se admiten datos numéricos", "validación de números", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

