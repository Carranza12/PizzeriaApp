using Pizzeria.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizzeria.metodos
{
    class PlatiilosCRUD
    {
        List<Platillo> menu = new List<Platillo>();

        internal List<Platillo> Menu { get => menu; set => menu = value; }

        public PlatiilosCRUD()
            
        
        {
            Platillo platillo1 = new Platillo("098765c-4556a-476833z", "pizza peperonni", 80,"pizza mediana de peperonni");
            Menu.Add(platillo1);

            Platillo platillo2 = new Platillo("4534c-45356a-45356z", "pizza con piña", 120, "pizza grande hawaiiana");
            Menu.Add(platillo2);

             Platillo platillo3 = new Platillo("123696c-90432a-123975z", "pizza vegetariana", 150, "pizza con vegetales");
            Menu.Add(platillo3);

        }
        public List<Platillo> MostrarMenu()
        {
            return Menu;
        }
        public void guardarPlatilloNuevo(string txtNombrePlatillo, String txtPrecioPlatillo,String txtDescripcionPlatillo,
             DataGridView tablaMenu, ErrorProvider validarPlatillos, TextBox txtNombrePlatilloCtrl,
             TextBox txtPrecioPlatillosCtrl,RichTextBox txtDescripcionPlatilloCtrl)
        {
            
            

            string CodigoAleatorio = string.Empty;
            CodigoAleatorio = Guid.NewGuid().ToString();
            if (txtNombrePlatillo.Equals("") && txtPrecioPlatillo.Equals("") && txtDescripcionPlatillo.Equals(""))
            {
                validarPlatillos.SetError(txtNombrePlatilloCtrl, "no puedes dejar los campos vacios");
                validarPlatillos.SetError(txtPrecioPlatillosCtrl, "no puedes dejar los campos vacios");
                validarPlatillos.SetError(txtDescripcionPlatilloCtrl, "no puedes dejar los campos vacios");
            }
            else
            {
                validarPlatillos.Clear();
                Platillo platilloNuevo = new Platillo(CodigoAleatorio, txtNombrePlatillo, Int32.Parse(txtPrecioPlatillo), txtDescripcionPlatillo);
                Menu.Add(platilloNuevo);
                tablaMenu.DataSource = null;
                tablaMenu.DataSource = Menu;
                MessageBox.Show("Platillo Agregado con exito");
            }
        }

        public void eliminarUnPlatillo(int indice)
        {
            Menu.RemoveAt(indice);
        }
        public void modificarPlatillo(int indice,String id, string txtNombrePlatillo, String txtPrecioPlatillo, String txtDescripcionPlatillo,
            ErrorProvider validarPlatillos,TextBox txtNombrePlatilloCtrl, TextBox txtPrecioPlatilloCtrl,
            RichTextBox txtDescripcionPlatilloCtrl)
        {
            

            if (txtNombrePlatillo.Equals("") || txtPrecioPlatillo.Equals("") || txtDescripcionPlatillo.Equals(""))
            {
                validarPlatillos.SetError(txtNombrePlatilloCtrl, "campo obligatorio");
                validarPlatillos.SetError(txtPrecioPlatilloCtrl, "campo obligatorio");
                validarPlatillos.SetError(txtDescripcionPlatilloCtrl, "campo obligario");
            }
            else
            {
                validarPlatillos.Clear();
                Platillo platilloModificado = new Platillo(id, txtNombrePlatillo, Int32.Parse(txtPrecioPlatillo), txtDescripcionPlatillo);
                Menu.RemoveAt(indice);
            }
        }

        List<platilloPedido> misPlatillos = new List<platilloPedido>();
        public List<platilloPedido> retornarPlatillos()
        {
            foreach(var item in menu)
            {
                platilloPedido miplatillo = new platilloPedido(item.Nombre,item.Precio);
                misPlatillos.Add(miplatillo);
            }
            return misPlatillos;
        }
        List<String> platillosNombres = new List<String>();
        public List<String> retornarNombrePlatillos()
        {
            foreach (var item in Menu)
            {
                platillosNombres.Add(item.Nombre);
            }
            return platillosNombres;
        }
        public String longitudPlatillos()
        {
            return Menu.Count().ToString();
        }
    }
    class platilloPedido
    {
        private string nombre;
        private double precio;
        public platilloPedido(String nombre,double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
    }

    
}
