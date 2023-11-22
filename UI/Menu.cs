using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void archivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        

        }

        private void realizarCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCompra oFrmCompra = new FrmCompra();
            oFrmCompra.MdiParent = this;
            oFrmCompra.Show();
            oFrmCompra.WindowState = FormWindowState.Maximized;
        }

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente oFrmCliente = new FrmCliente();
            oFrmCliente.MdiParent = this;
            oFrmCliente.Show();
            oFrmCliente.WindowState = FormWindowState.Maximized;
        }

        private void Menu_Load(object sender, EventArgs e)
        {

            Ingreso oIngreso = new Ingreso();
          
            oIngreso.MdiParent = this;
            oIngreso.Show();
            oIngreso.WindowState = FormWindowState.Maximized;



        }



        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProducto oFrmProducto = new FrmProducto();
            oFrmProducto.MdiParent = this;
            oFrmProducto.Show();
            oFrmProducto.WindowState = FormWindowState.Maximized;
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ingreso oIngreso = new Ingreso();
            oIngreso.MdiParent = this;
            oIngreso.Show();
            oIngreso.WindowState = FormWindowState.Maximized;
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registro oRegistro = new Registro();
            oRegistro.MdiParent = this;
            oRegistro.Show();
            oRegistro.WindowState = FormWindowState.Maximized;
        }
    }
}
