using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria.metodos
{
    class SucursalesCRUD
       
    {
        List<Sucursal> listaSucursal = new List<Sucursal>();

        internal List<Sucursal> ListaSucursal { get => listaSucursal; set => listaSucursal = value; }

        public SucursalesCRUD()
        {
            Sucursal sucursal1 = new Sucursal("098765c-4556a-476833z", "Sucursal fresno", "fresno #456", "346844556");
            listaSucursal.Add(sucursal1);

            Sucursal sucursal2 = new Sucursal("4534c-45356a-45356z", "Sucursal Centro", "Av. Allende #10", "346844556");
            listaSucursal.Add(sucursal2);

            Sucursal sucursal3 = new Sucursal("123696c-90432a-123975z", "Sucursal Periferico", "periferico #1209", "346844556");
            listaSucursal.Add(sucursal3);

        }
        public List<Sucursal> MostrarSucursales()
        {
            return listaSucursal;
        }
        public void guardarSucursalNueva(string txtNombre,String txtDireccion,
            String txtTelefono,DataGridView tablaSucursales, ErrorProvider validarSucursales,
            TextBox txtNombreCtrl,TextBox txtDireccionCtrl, TextBox txtTelefenoCtrl
            )
        {
            string IDAleatoria = string.Empty;
            IDAleatoria = Guid.NewGuid().ToString();
            if (txtNombre.Equals("") && txtDireccion.Equals("") && txtTelefono.Equals("")) 
            {
                validarSucursales.SetError(txtNombreCtrl, "no puedes dejar los campos vacios");
                validarSucursales.SetError(txtDireccionCtrl, "no puedes dejar los campos vacios");
                validarSucursales.SetError(txtTelefenoCtrl, "no puedes dejar los campos vacios");
            }
            else
            {
                validarSucursales.Clear();
                Sucursal sucursalNueva = new Sucursal(IDAleatoria, txtNombre, txtDireccion, txtTelefono);
                listaSucursal.Add(sucursalNueva);
                tablaSucursales.DataSource = null;
                tablaSucursales.DataSource = listaSucursal;
                MessageBox.Show("Sucursal Agregada con exito");
            }
            
        }

        public void eliminarUnaSucursal(int indice)
        {
           listaSucursal.RemoveAt(indice);
        }
        public void modificarSucursal(int indice,String txtNombreNuevo, String txtDireccionNueva,String txtTelefonoNuevo,String id,
            ErrorProvider validarSucursales,TextBox txtNombre, TextBox txtDireccion, TextBox txtTelefono)
        {
            if(txtNombreNuevo.Equals("") || txtDireccionNueva.Equals("") || txtTelefonoNuevo.Equals(""))
            {
                validarSucursales.SetError(txtNombre, "campo obligatorio");
                validarSucursales.SetError(txtDireccion, "campo obligatorio");
                validarSucursales.SetError(txtTelefono, "campo obligario");
            }
            else
            {
                validarSucursales.Clear();
                Sucursal sucursalModificada = new Sucursal(id, txtNombreNuevo, txtDireccionNueva, txtTelefonoNuevo);
                listaSucursal.RemoveAt(indice);
                listaSucursal.Insert(indice, sucursalModificada);
            }
        }
        public String longitudSucursales()
        {
            return listaSucursal.Count().ToString();
        }




        List<String> SucursalesNombres = new List<String>();
        public List<String> retornarNombreSucursales()
        {
            foreach(var item in listaSucursal)
            {
                SucursalesNombres.Add(item.Nombre);
            }
            return SucursalesNombres;
        }
    }
}
