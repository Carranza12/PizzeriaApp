using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class Sucursal
    {
        private String id;
        private String nombre;
        private String direccion;
        private String telefono;
        public Sucursal(String id,String nombre,String direccion,String telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }
        public Sucursal()
        {

        }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Id { get => id; set => id = value; }
    }
}
