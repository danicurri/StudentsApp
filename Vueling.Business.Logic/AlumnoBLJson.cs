using System;
using Vueling.Common.Logic.Model;
using Vueling.DataAccess.Dao;

namespace Vueling.Business.Logic
{
    public class AlumnoBLJson : IAlumnoBL
    {
        public Alumno Add(Alumno alumno)
        {
            DateTime actualidad = DateTime.Today;
            alumno.Edad = actualidad.Year - alumno.FechaNacimiento.Year;
            if (actualidad < alumno.FechaNacimiento.AddYears(alumno.Edad)) alumno.Edad--;
            alumno.FechaAgregado = actualidad;            
            alumno.FechaNacimiento = DateTime.ParseExact(alumno.FechaNacimiento.ToString("dd/MM/yyyy"),"d",null);
            IAlumnoDAO alumnoDAO = new AlumnoDAOJson();
            Alumno agregado = alumnoDAO.Add(alumno);
            return agregado;
        }

        public Alumno Search(string nombre, string apellidos)
        {
            IAlumnoDAO alumnoDAO = new AlumnoDAOJson();           
            throw new NotImplementedException();
        }
    }
}
