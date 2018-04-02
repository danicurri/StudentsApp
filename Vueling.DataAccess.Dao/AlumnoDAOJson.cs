using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;

namespace Vueling.DataAccess.Dao
{
    public class AlumnoDAOJson : IAlumnoDAO
    {
        private string path;

        public AlumnoDAOJson()
        {
            path = FileUtils.Folder + "Alumnos.json";
        }

        /// <summary>
        /// Agrega el alumno pasado como parametro al archivo del formato json.
        /// Esto es asi, siempre y cuando no exista ya un alumno con los mismos atributos.
        /// </summary>        
        /// <param name="alumno">Alumno a guardar en el archivo.</param>        
        public Alumno Add(Alumno alumno)
        {
            Alumno alumnoAgregado = new Alumno();
            if (Search(alumno) == null)
            {
                var jsonData = File.ReadAllText(path);
                var listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(jsonData) ?? new List<Alumno>(); ;
                listaAlumnos.Add(alumno);
                jsonData = JsonConvert.SerializeObject(listaAlumnos);
                File.WriteAllText(FileUtils.Folder + "Alumnos.json", jsonData);
                alumnoAgregado = alumno;
            }
            return alumnoAgregado;
        }

        /// <summary>
        /// Busca el alumno especificado en el archivo del formato json.
        /// </summary>        
        /// <param name="alumno">Alumno a buscar en el archivo.</param>
        /// <returns>Devuelve el alumno si lo encuentra, o null en caso contrario.</returns>
        public Alumno Search(Alumno alumno)
        {
            Alumno encontrado = null;
            var jsonData = File.ReadAllText(path);
            var listaAlumnos = JsonConvert.DeserializeObject<List<Alumno>>(jsonData) ?? new List<Alumno>(); ;
            int i = 0;
            while (encontrado == null && i < listaAlumnos.Count)
            {
                if (alumno.Equals(listaAlumnos[i]))
                    encontrado = listaAlumnos[i];
                ++i;
            }
            return encontrado;
        }
    }
}
