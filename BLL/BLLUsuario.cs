using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using BE;
using MPP;

namespace BLL
{
    public class BLLUsuario
    {

        

        public BLLUsuario()
        {
            oMPPUsuario = new MPPUsuario();
        }
        MPPUsuario oMPPUsuario;

        public bool VerificarCredenciales(BEUsuario oBEUsuario)
        {
            return oMPPUsuario.VerificarCredenciales(oBEUsuario);
        }
        public bool crearCredenciales(BEUsuario oBEUsuario)
        {
            return oMPPUsuario.CrearCredencial(oBEUsuario);
        }
        public void GuardarEnXML(List<BEUsuario> usuarios, string rutaArchivo)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<BEUsuario>));

                using (TextWriter writer = new StreamWriter(rutaArchivo))
                {
                    serializer.Serialize(writer, usuarios);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<BEUsuario> LeerDesdeXML(string rutaArchivo)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<BEUsuario>));

                using (TextReader reader = new StreamReader(rutaArchivo))
                {
                    return (List<BEUsuario>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
