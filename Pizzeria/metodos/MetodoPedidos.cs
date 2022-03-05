using Pizzeria.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Pizzeria.metodos
{
    class MetodoPedidos
    {
        List<Pedido> misPedidos = new List<Pedido>();
        public MetodoPedidos()
        {
            Pedido miPedido = new Pedido("Francisco Carranza", "Sucursal Centro", "Pizza con piña");
            misPedidos.Add(miPedido);
            
        }
        
        public void agregarNuevoPedido(String txtNombreCliente,String cbSucursal, String cbPlatillo,
            DataGridView dgvPedidos)
        {
            Pedido miPedido = new Pedido(txtNombreCliente, cbSucursal, cbPlatillo);
            misPedidos.Add(miPedido);
            dgvPedidos.DataSource = null;
            dgvPedidos.DataSource = misPedidos;
            MessageBox.Show("Pedido Agregado con exito");
        }

        public String longitudPedidos()
        {
            return misPedidos.Count().ToString();
        }
        public List<Pedido> retornarMisPedidos()
        {
            return misPedidos;
        }

    }
}
