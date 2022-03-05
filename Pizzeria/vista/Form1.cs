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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Validacion validar = new Validacion();
        Dashboard dashboard = new Dashboard();
        public void validacion()
        {
            if (validar.validacionCampos(txtUsuario.Text,txtClave.Text,txtUsuario,txtClave))
            {
               
                dashboard.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            validacion();
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
