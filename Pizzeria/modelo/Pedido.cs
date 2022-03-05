using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzeria.modelo
{
    class Pedido
    {
        private String nombreCliente;
        private String sucursal;
        private String platillo;

        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string Sucursal { get => sucursal; set => sucursal = value; }
        public string Platillo { get => platillo; set => platillo = value; }

        public Pedido(string nombreCliente, string sucursal, string platillo)
        {
            this.nombreCliente = nombreCliente;
            this.sucursal = sucursal;
            this.platillo = platillo;
        }

        public Pedido()
        {

        }
        
    }
}
