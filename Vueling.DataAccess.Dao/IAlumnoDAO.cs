using Vueling.Common.Logic.Model;

namespace Vueling.DataAccess.Dao
{
    public interface IAlumnoDAO
    {
        Alumno Add(Alumno alumno);
        Alumno Search(Alumno alumno);
    }
}
