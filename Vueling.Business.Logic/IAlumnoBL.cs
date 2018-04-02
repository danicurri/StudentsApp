
using Vueling.Common.Logic.Model;

namespace Vueling.Business.Logic
{
    public interface IAlumnoBL
    {       
        
        // lo ideal es que esta interfaz generase genericos T
        // esta interfaz se tiene que crear en el DAO tambien para desaclopamiento
        // si ponemos esta dll en otra máquina no dependa de Common
        // o ponerla en common una sola vez (que generaria esa dependencia)
        Alumno Add(Alumno alumno);
        Alumno Search(string nombre, string apellidos);
    }
}
