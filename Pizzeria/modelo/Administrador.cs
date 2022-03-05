using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria
{
    class Administrador
    {
        private String usuario;
        private String clave;

        public Administrador(String usuario,String clave)
        {
            this.usuario = usuario;
            this.clave = clave;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Clave { get => clave; set => clave = value; }
    }
}
