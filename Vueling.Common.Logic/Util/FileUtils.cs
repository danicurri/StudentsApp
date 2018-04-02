using System;
using System.IO;
using System.Xml.Linq;
using static Vueling.Common.Logic.Util.Constants;

namespace Vueling.Common.Logic.Util
{
    public class FileUtils
    {
        public static string Folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
        public OpcionFormato opcionFormato;

        public FileUtils()
        {
            if (!File.Exists(Folder + "Alumnos.txt"))
            {
                FileStream fs = File.Create(Folder + "Alumnos.txt");
                fs.Close();
            }
            if (!File.Exists(Folder + "Alumnos.json"))
            {
                FileStream fs = File.Create(Folder + "Alumnos.json");
                fs.Close();
            }
            if (!File.Exists(Folder + "Alumnos.xml"))
            {
                XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf - 16", "true"),                
                new XElement("AlumnoCollection"));
                doc.Save(Folder + "Alumnos.xml");
                //FileStream fs = File.Create(Folder + "Alumnos.xml");
                //fs.Close();
            }
        }

        /// <summary>
        /// Inicializa el formato en el que guardar los alumnos si no esta definido.
        /// En caso contrario, utiliza el formato definido.
        /// </summary>
        /// <returns>Devuelve el formato a utilizar para guardar los alumnos.</returns>
        public OpcionFormato InicializarConfiguracion()
        {
            OpcionFormato opcion;
            // Si hay un formato definido lo guardamos, si no lo definimos como txt por defecto.            
            string formato = Environment.GetEnvironmentVariable("Formato", EnvironmentVariableTarget.User);
            if (String.IsNullOrEmpty(formato))
            {
                opcion = OpcionFormato.txt;
                Environment.SetEnvironmentVariable("Formato", "txt", EnvironmentVariableTarget.User);
            }
            else
            {
                if (formato == "txt")
                {
                    Environment.SetEnvironmentVariable("Formato", "txt", EnvironmentVariableTarget.User);
                    opcion = OpcionFormato.txt;
                }
                else
                {
                    Environment.SetEnvironmentVariable("Formato", "json", EnvironmentVariableTarget.User);
                    opcion = OpcionFormato.json;
                }
            }
            opcionFormato = opcion;
            return opcion;
        }

        public void CambiarConfiguracion(OpcionFormato opcionFormato)
        {
            switch (opcionFormato)
            {
                case OpcionFormato.txt:
                    Environment.SetEnvironmentVariable("Formato", "txt", EnvironmentVariableTarget.User);
                    this.opcionFormato = opcionFormato;
                    break;
                case OpcionFormato.json:
                    Environment.SetEnvironmentVariable("Formato", "json", EnvironmentVariableTarget.User);
                    this.opcionFormato = opcionFormato;
                    break;
                default:
                    break;
            }
        }
    
}
}
