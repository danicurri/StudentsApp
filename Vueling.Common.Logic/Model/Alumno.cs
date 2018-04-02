using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Vueling.Common.Logic.Model
{
    [Serializable()]
    [XmlRoot("AlumnoCollection")]
    public class AlumnoCollection
    {
        [XmlArray("Alumnos")]
        [XmlArrayItem("Alumno", typeof(Alumno))]
        public List<Alumno> Alumnos { get; set; }
    }

    [Serializable()]    
    public class Alumno : VuelingModelObject
    {
        #region Authomatic Properties

        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Nombre")]
        public string Nombre { get; set; }
        [XmlElement("Apellidos")]
        public string Apellidos { get; set; }
        [XmlElement("Dni")]
        public string Dni { get; set; }
        [XmlElement("FechaNacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [XmlElement("Edad")]
        public int Edad { get; set; } // se calcula a partir de la fecha de nacimiento
        [XmlElement("FechaAgregado")]
        public DateTime FechaAgregado { get; set; }

        #endregion

        #region Constructors

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellidos, string dni, DateTime fechaNacimiento, Guid guid)
        {
            Id = id;
            Nombre = nombre;
            Apellidos = apellidos;
            Dni = dni;
            Guid = guid;
            FechaNacimiento = fechaNacimiento;            
        }

        #endregion

        #region Public methods

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Alumno alumno = (Alumno)obj;
            if (/*Guid == alumno.Guid &&*/ Id == alumno.Id && Nombre == alumno.Nombre && Apellidos == alumno.Apellidos && Dni == alumno.Dni && FechaNacimiento == alumno.FechaNacimiento)
                return true;

            return false;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode() * 17 + Nombre.GetHashCode() + Apellidos.GetHashCode() + Dni.GetHashCode() + Guid.GetHashCode() + FechaNacimiento.GetHashCode();
        }

        /// <summary>
        /// deberia haber un metodo tostring para txt, json y este ser usado para escribir en los archivos de distinto formato
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Id.ToString() + "," + Nombre + "," + Apellidos + "," + Dni + "," + FechaNacimiento.ToString("dd/MM/yyyy") + "," + Edad + "," + Guid;
        }

        #endregion
    }
}
