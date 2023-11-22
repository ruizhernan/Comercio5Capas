using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public partial class Ingreso : Form
    {
        public Ingreso()
        {
            InitializeComponent();
            oBEUsuario = new BEUsuario();
            oBLLUsuario = new BLLUsuario();

        }
        BEUsuario oBEUsuario;
        BLLUsuario oBLLUsuario;


        private void btnIngreso_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrEmpty(txtPw.Text))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña");
            }
            else
            {
                string clavehash = ObtenerHash(txtPw.Text);

                oBEUsuario.Usuario = txtUser.Text;
                oBEUsuario.pass = clavehash;


                if (oBLLUsuario.VerificarCredenciales(oBEUsuario))
                {
                    MessageBox.Show("Usuario correcto!");
                    this.Hide();

                }
            }

       

        }

        private void lblRegistro_Click(object sender, EventArgs e)
        {
            Registro oRegistro = new Registro();
            oRegistro.Show();
            
        }

        public string ObtenerHash(string contraseña)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(contraseña);
                byte[] hash = sha256.ComputeHash(bytes);


                StringBuilder cadenahasheada = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    cadenahasheada.Append(hash[i].ToString("x2"));
                }

                return cadenahasheada.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void Ingreso_Load(object sender, EventArgs e)
        {

        }
    }
}
