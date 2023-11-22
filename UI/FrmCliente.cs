using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
namespace UI
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
            oBLLCliente = new BLLCliente();
            oBECliente = new BECliente();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            CargarDTGV();
        }
        BLLCliente oBLLCliente;
        BECliente oBECliente;

        void CargarDTGV()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = oBLLCliente.CargarListaClientes();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Modificar
            Asignar();
            oBLLCliente.Guardar(oBECliente);
            MessageBox.Show("Cliente modificado correctamente");
            Limpiar();
            CargarDTGV();
        }

        private void Asignar()
        {
            oBECliente.Nombre = textBox1.Text;
            oBECliente.Direccion = textBox2.Text;
        }
        private void Limpiar()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            oBECliente = (BECliente)this.dataGridView1.CurrentRow.DataBoundItem;
            textBox1.Text = oBECliente.Nombre;
            textBox2.Text = oBECliente.Direccion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Agregar
            Asignar();
            oBLLCliente.Guardar(oBECliente);
            MessageBox.Show("Cliente agregado correctamente");
            Limpiar();
            CargarDTGV();
        }

        private void button3_Click(object sender, EventArgs e)
        { //Borrar
            Asignar();
            oBLLCliente.Eliminar(oBECliente);
            MessageBox.Show("Cliente eliminado correctamente");
            Limpiar();
            CargarDTGV();

        }
    }
}
