using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class FrmCompra : Form
    {
        public FrmCompra()
        {
            InitializeComponent();
            
            oBEProducto = new BEProducto();
            oBLLProducto = new BLLProducto();
            oBECliente = new BECliente();
            oBECompra = new BECompra();
            oBLLCliente = new BLLCliente();
            oBLLDetalleCompra = new BLLDetalleCompra();
            oBLLCompra = new BLLCompra();
            oBEPagoTarjeta = new BEPagoTarjeta();
            oBLLPagoTarjeta = new BLLPagoTarjeta();
            oBLLPagoEft = new BLLPagoEft();
            oBEPagoEft = new BEPagoEft();
            carrito = new List<DetalleCompra>();
            
        }
        #region Inicializaciones
        BEProducto oBEProducto;
        BLLProducto oBLLProducto;
        BLLCliente oBLLCliente;
        BECliente oBECliente;
        BECompra oBECompra;
        BLLCompra oBLLCompra;
        BLLDetalleCompra oBLLDetalleCompra;
        BLLPagoEft oBLLPagoEft;
        BEPagoEft oBEPagoEft;
        BEPagoTarjeta oBEPagoTarjeta;
        BLLPagoTarjeta oBLLPagoTarjeta;
        List<DetalleCompra> carrito;
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCompra_Load(object sender, EventArgs e)
        {
            cmbProdu.DataSource = null;

            cmbProdu.DataSource = oBLLProducto.CargarListaProductos();
            cmbProdu.ValueMember = "Nombre";
            cmbProdu.Refresh();

            cmbClient.DataSource = null;
            cmbClient.DataSource = oBLLCliente.CargarListaClientes();
            cmbClient.ValueMember = "Nombre";
            cmbClient.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //AgregarProducto
            asignar();
            DetalleCompra detalle = new DetalleCompra
            {
                producto = oBEProducto.Nombre,
                Cantidad = Convert.ToInt32(textBox1.Text),
                Precio = oBEProducto.Precio
            };
            carrito.Add(detalle);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = carrito;
            dataGridView1.Refresh();
        }

        void asignar()
        {
            oBEProducto = (BEProducto)cmbProdu.SelectedItem;
            oBEProducto.Id = oBEProducto.Id;

            oBECliente = (BECliente)cmbClient.SelectedItem;
            oBECliente.ID = oBECliente.ID;
            
            int cant = Convert.ToInt32(textBox1.Text);
            
            oBECompra.Total = cant * oBEProducto.Precio;
            
            bool pagoTarjeta = radioButton1.Checked;
            bool pagoEft = radioButton2.Checked;
            #region Polimorfismo
            if (pagoTarjeta)
            {
                oBLLPagoTarjeta = new BLLPagoTarjeta();
                oBEPagoTarjeta.Monto = oBECompra.Total;
               oBECompra.Total = oBECompra.Total + (oBLLPagoTarjeta.CalcularMontoFinal(oBEPagoTarjeta));
            }
            if (pagoEft)
            {
                oBLLPagoEft = new BLLPagoEft();
                oBEPagoEft.Monto = oBECompra.Total;
                oBECompra.Total = oBECompra.Total - (oBLLPagoEft.CalcularMontoFinal(oBEPagoEft));
            }
            #endregion
        }


        void armarCarrito()
        {
            
            DataTable DT = new DataTable();
            DT.Columns.Add("Articulo", typeof(string));
            DT.Columns.Add("Cantidad", typeof(int));

            BEProducto producto = (BEProducto)cmbProdu.SelectedItem;

            int cantidad = Convert.ToInt32(textBox1.Text);

            DT.Rows.Add(producto.Nombre, cantidad);

            dataGridView1.DataSource = DT;
            dataGridView1.Refresh();
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
             // Finalizar compra
        asignar();

        
        oBLLCompra.Guardar(oBECompra, oBECliente);

        carrito.Clear();
        dataGridView1.DataSource = null;
        dataGridView1.Refresh();
            
        }
    }
}
