using BE;
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
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Drawing.Text;

namespace UI
{
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            oBEUsuario = new BEUsuario();
            oBLLUsuario = new BLLUsuario();
            ListaDeUsuarios = new List<BEUsuario>();
            

    }
        BEUsuario oBEUsuario;
        BLLUsuario oBLLUsuario;
        List<BEUsuario> ListaDeUsuarios;
    

        private void btnRegistro_Click(object sender, EventArgs e)
        {

            
            if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrEmpty(txtPw.Text))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña");
            }
            else
            {
                string clavehash = ObtenerHash(txtPw.Text);

                oBEUsuario.Usuario = txtUser.Text;
                oBEUsuario.pass = clavehash;

                if (oBLLUsuario.crearCredenciales(oBEUsuario))
                {
                   MessageBox.Show("Usuario ingresado");
                    GuardarUsuariosEnXML(@"C:\\Users\\Hernan\\Documents\\Visual Studio 2022\\Code Snippets\\XML\\Usuarios.xml");

                    this.Hide();
               }
            }



            

        }
        private void CargarUsuariosDesdeXML(string rutaArchivo)
        {

            try
            {
                if (File.Exists(rutaArchivo))
                {
                    XElement xml = XElement.Load(rutaArchivo);

                    ListaDeUsuarios = (
                        from usuario in xml.Elements("Usuario")
                        select new BEUsuario
                        {
                            ID = int.Parse(usuario.Element("ID").Value),
                            Usuario = usuario.Element("Nombre").Value,
                        }).ToList();
                    dataGridView1.DataSource = ListaDeUsuarios;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios desde el archivo XML: " + ex.Message);
            }
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

        private void Registro_Load(object sender, EventArgs e)
        { }
        private void GuardarUsuariosEnXML(string rutaArchivo)
        {
            try
            {
                XElement xml;

                
                if (File.Exists(rutaArchivo))
                {
                    
                    xml = XElement.Load(rutaArchivo);
                }
                else
                {
                   
                    xml = new XElement("Usuarios");
                }

               
                foreach (var usuario in ListaDeUsuarios)
                {
                    XElement usuarioXml = new XElement("Usuario",
                        new XElement("ID", usuario.ID),
                        new XElement("Nombre", usuario.Usuario),
                        new XElement("Password", usuario.pass)
                    );

                    xml.Add(usuarioXml);
                }

                
                xml.Save(rutaArchivo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar usuarios en el archivo XML: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
          
            CargarUsuariosDesdeXML(@"C:\\Users\\Hernan\\Documents\\Visual Studio 2022\\Code Snippets\\XML\\Usuarios.xml");
        }
    }
}
