using System;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;

namespace Vueling.Business.Logic
{
    public class AlumnoBLTxt : IAlumnoBL
    {        
        public Alumno Add(Alumno alumno)
        {
            DateTime actualidad = DateTime.Today;
            alumno.Edad = actualidad.Year - alumno.FechaNacimiento.Year;
            if (actualidad < alumno.FechaNacimiento.AddYears(alumno.Edad)) alumno.Edad--;
            alumno.FechaAgregado = actualidad;
            IAlumnoDAO alumnoDAO = new AlumnoDAOTxt();
            Alumno agregado = alumnoDAO.Add(alumno);
            return agregado;
        }

        public Alumno Search(string nombre, string apellidos)
        {
            IAlumnoDAO alumnoDAO = new AlumnoDAOTxt();
            throw new NotImplementedException();
        }
    }
}
