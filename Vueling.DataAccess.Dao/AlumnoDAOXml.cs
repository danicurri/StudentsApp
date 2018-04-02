using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDAOXml : IAlumnoDAO
    {
        private string path;

        public AlumnoDAOXml()
        {
            path = FileUtils.Folder + "Alumnos.xml";
        }

        public Alumno Add(Alumno alumno)
        {
            Alumno alumnoAgregado = new Alumno();
            if (Search(alumno) == null)
            {
                // obtienes la coleccion de alumnos del archivo
                AlumnoCollection alumnos = null;
                XmlSerializer serializer = new XmlSerializer(typeof(AlumnoCollection));
                StreamReader reader = new StreamReader(path);
                alumnos = (AlumnoCollection)serializer.Deserialize(reader);                
                reader.Close();
                // añades el nuevo alumno a la coleccion
                alumnos.Alumnos.Add(alumno);
                // serializas la coleccion modificada en el archivo
                XmlSerializer writer = new XmlSerializer(typeof(AlumnoCollection));
                FileStream file = File.Create(path);
                writer.Serialize(file, alumnos);
                file.Close();
            }
            return alumnoAgregado;
        }

        public Alumno Search(Alumno alumno)
        {
            // obtienes la coleccion de alumnos del archivo
            AlumnoCollection alumnos = null;
            XmlSerializer serializer = new XmlSerializer(typeof(AlumnoCollection));
            StreamReader reader = new StreamReader(path);
            alumnos = (AlumnoCollection)serializer.Deserialize(reader);
            reader.Close();
            Alumno encontrado = null;
            // buscas el alumno en dicha coleccion
            if (alumnos.Alumnos != null)
            {
                int i = 0;
                while (encontrado == null && i < alumnos.Alumnos.Count)
                {
                    if (alumnos.Alumnos[i].Equals(alumno))
                        encontrado = alumno;
                    ++i;
                }                
            }            
            return encontrado;
        }
    }
}
