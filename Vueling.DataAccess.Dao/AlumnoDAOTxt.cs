using System;
using System.Globalization;
using System.IO;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDAOTxt : IAlumnoDAO
    {
        private string path;

        public AlumnoDAOTxt()
        {
            path = FileUtils.Folder + "Alumnos.txt";
        }

        /// <summary>
        /// Agrega el alumno pasado como parametro al archivo del formato txt.
        /// Esto es asi, siempre y cuando no exista ya un alumno con los mismos atributos.
        /// </summary> 
        /// <param name="alumno">Alumno a guardar en el archivo.</param>    
        public Alumno Add(Alumno alumno)
        {
            Alumno alumnoAgregado = new Alumno();
            if (Search(alumno) == null)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(alumno.ToString());
                    alumnoAgregado = alumno;
                }
            }
            return alumnoAgregado;
        }

        /// <summary>
        /// Busca el alumno especificado en el archivo del formato txt.
        /// </summary>        
        /// <param name="alumno">Alumno a buscar en el archivo.</param>
        /// <returns>Devuelve el alumno si lo encuentra, o null en caso contrario.</returns>
        public Alumno Search(Alumno alumno)
        {
            Alumno encontrado = null;
            string[] lines = File.ReadAllLines(path);
            int i = 0;
            while (encontrado == null && i < lines.Length)
            {
                string[] atributosAlumno = lines[i].Split(',');                
                Alumno alumnoAuxiliar = new Alumno(Convert.ToInt32(atributosAlumno[0]), atributosAlumno[1], atributosAlumno[2], atributosAlumno[3], DateTime.ParseExact(atributosAlumno[4], "d", null), new Guid(atributosAlumno[5]));
                if (alumnoAuxiliar.Equals(alumno))
                    encontrado = alumnoAuxiliar;
                ++i;
            }
            return encontrado;
        }
        
    }
}
