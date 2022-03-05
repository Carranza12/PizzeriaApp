using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.modelo
{
    class Platillo
    {
        private String codigo;
        private String nombre;
        private double precio;
        private String descripcion;
        public Platillo()
        {

        }
        public Platillo(String codigo,String nombre, double precio,String descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
    

}
