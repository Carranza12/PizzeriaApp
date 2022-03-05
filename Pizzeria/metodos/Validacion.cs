using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria
{
    class Validacion //clase para validaciones del sistema
    {
        Administrador admin;
        public Validacion()
        {
            this.admin = new Administrador("admin", "12345");
        }
        public Boolean validacionCampos(String txtUsuario,String txtClave, TextBox txtU, TextBox txtC)
        {
            bool OK=false;
            
            Form1 form1 = new Form1();
            form1.validarCampos.Clear();
            if (txtUsuario.Equals("") && txtClave.Equals(""))
            {
                OK = false;
                form1.validarCampos.SetError(txtU,"Usuario obligatorio");
                form1.validarCampos.SetError(txtC, "Clave obligatoria");
            }
            else
            {
                if(txtUsuario.Length<5 && txtClave.Length < 5)
                {
                    form1.validarCampos.SetError(txtU, "Usuario debe tener minimo 5 caracteres");
                    form1.validarCampos.SetError(txtC, "Clave debe tener minimo 5 caracteres");
                }
                if(txtUsuario.Length > 20 && txtClave.Length > 20)
                {
                    form1.validarCampos.SetError(txtU, "Usuario debe tener maximo 20 caracteres");
                    form1.validarCampos.SetError(txtC, "Clave debe tener maximo 20 caracteres");

                }
                if(txtUsuario.Equals("admin")&& txtClave.Equals("12345"))
                {
                    OK = true;
                    return OK;
                    form1.validarCampos.Clear();
                }
            }
            return OK;
            form1.validarCampos.Clear();
        }
        public Boolean validacionSistema(String txtUsuario,String txtClave) // valida si se puede acceder al dashboard principal
        {
            if (txtUsuario.Equals("admin") && txtClave.Equals("12345"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
