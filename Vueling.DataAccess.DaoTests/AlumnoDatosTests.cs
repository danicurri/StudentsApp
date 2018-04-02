using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;
using static Vueling.Common.Logic.Util.Constants;

namespace Vueling.DataAccess.Dao.Tests
{
    [TestClass()]
    public class AlumnoDatosTests
    {
        [DataRow(1, "Pepe", "Ramirez", "4356789W", "12/03/1987", OpcionFormato.txt)]
        [DataRow(1, "Pepe", "Ramirez", "4356789W", "01/06/1965", OpcionFormato.json)]
        [DataRow(2, "Maria", "Delao", "435623429T", "04/01/1991", OpcionFormato.json)]
        [DataRow(1, "Pepe", "Ramirez", "4356789W", "09/12/1954", OpcionFormato.txt)]
        [DataTestMethod] // permite enviar datos al método de test (parametrizar)
        public void AgregarTest(int id, string nombre, string apellidos, string dni, string fechaNacimiento, OpcionFormato opcionFormato)
        {
            // Lo correcto seria que cada proyecto tuviera su app.config pero .NET
            // solo permite ficheros de configuración en aplicaciones de consola, windows form y web
            // en este sentido la cadena de conexión iría en el archivo de configuracion del proyecto de acceso a datos
            // el fichero de configuracion se puede acceder des del app domain
            // dao.xml se guarda al lado del compilado y se crea un codigo que lo lee
            Guid guid = new Guid();
            DateTime dt = DateTime.Parse(fechaNacimiento, new CultureInfo("es-ES", true));
            Alumno alumnoAgregado = new Alumno(id, nombre, apellidos, dni, dt, guid);
            FileUtils utilidadesArchivos = new FileUtils();
            utilidadesArchivos.CambiarConfiguracion(opcionFormato);
            AlumnoDatos alumnoDatos;
            if (opcionFormato == OpcionFormato.txt)
                alumnoDatos = new AlumnoDatosTxt();
            else
                alumnoDatos = new AlumnoDatosJson();
            alumnoDatos.Agregar(alumnoAgregado);
            Alumno alumnoEncontrado = alumnoDatos.Buscar(alumnoAgregado);
            Assert.AreEqual(alumnoAgregado, alumnoEncontrado);
        }

        /// <summary>
        ///Initialize() is called once during test execution before
        ///test methods in this test class are executed.
        ///</summary>
        [TestInitialize()]
        public void Initialize()
        {
            //FileStream fs;            
            //if (!File.Exists("Alumnos.txt"))
            //    fs = new FileStream("Alumnos.txt", FileMode.CreateNew);
            //if (!File.Exists("Alumnos.json"))
            //    fs = new FileStream("Alumnos.json", FileMode.CreateNew);
        }

        /// <summary>
        ///Cleanup() is called once during test execution after
        ///test methods in this class have executed unless
        ///this test class' Initialize() method throws an exception.
        ///</summary>
        [TestCleanup()]
        public void Cleanup()
        {
            if (File.Exists(FileUtils.Folder + "Alumnos.txt"))
                File.Delete(FileUtils.Folder + "Alumnos.txt");
            if (File.Exists(FileUtils.Folder + "Alumnos.json"))
                File.Delete(FileUtils.Folder + "Alumnos.json");
        }

    }
}