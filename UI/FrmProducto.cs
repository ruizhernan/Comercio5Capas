using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
            oBEProducto = new BEProducto();
            oBLLProducto = new BLLProducto();   
        }

        
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarDTGV();

        }

        BEProducto oBEProducto;
        BLLProducto oBLLProducto;

        void CargarDTGV()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLProducto.CargarListaProductos();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Red;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        void Asignacion()
        {
           
            oBEProducto.Nombre = textBox1.Text;
            oBEProducto.Precio = Convert.ToInt32(textBox2.Text);
        }

        void Limpiar()
        {
            textBox1.Text = string.Empty; textBox2.Text = string.Empty;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //BTn Agregar
            Asignacion();
            if (textBox1.Text != string.Empty && textBox2.Text != string.Empty) { 
                oBLLProducto.Guardar(oBEProducto);
            Limpiar();
            CargarDTGV();
            }
            else
            {
                MessageBox.Show("Debe ingresar valores para hacer el alta");
            }

        }

      

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            oBEProducto = (BEProducto)this.dataGridView1.CurrentRow.DataBoundItem;
            textBox1.Text = oBEProducto.Nombre;
            textBox2.Text = oBEProducto.Precio.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BTn Modificar

            Asignacion();
             
            oBLLProducto.Guardar(oBEProducto);
            Limpiar();
            CargarDTGV();
            
          

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //BTN eliminar

            Asignacion();
            oBLLProducto.Eliminar(oBEProducto);
            Limpiar();
            CargarDTGV();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
