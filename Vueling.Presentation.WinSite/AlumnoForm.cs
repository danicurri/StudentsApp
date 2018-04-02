using System;
using System.Windows.Forms;
using Vueling.Business.Logic;
using Vueling.Common.Logic.Model;
using Vueling.Common.Logic.Util;

namespace Vueling.Presentation.WinSite
{
    public partial class AlumnoForm : Form
    {
        private IAlumnoBL alumnoBL;
        private Alumno alumno;

        public AlumnoForm()
        {
            InitializeComponent();
            FileUtils fileUtils = new FileUtils();
        }

        private void btnTxt_Click(object sender, EventArgs e)
        {
            alumnoBL = new AlumnoBLTxt();
            LoadAlumnoData();
        }

        private void btnJson_Click(object sender, EventArgs e)
        {
            alumnoBL = new AlumnoBLJson();
            LoadAlumnoData();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            alumnoBL = new AlumnoBLXml();
            LoadAlumnoData();
        }

        private void LoadAlumnoData()
        {            
            alumno = new Alumno(Convert.ToInt32(txtId.Text), txtNombre.Text, txtApellidos.Text, txtDni.Text, dateTimePickerFechaNacimiento.Value, Guid.NewGuid());
            alumnoBL.Add(alumno);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreBuscar.Text;
            string apellidos = txtApellidosBuscar.Text;
            string formato = cmbBoxFormato.SelectedText;
            switch (formato)
            {
                case "Txt":
                    alumnoBL = new AlumnoBLTxt();
                    alumnoBL.Search(nombre,apellidos);
                    break;
                case "Json":
                    alumnoBL = new AlumnoBLJson();
                    alumnoBL.Search(nombre, apellidos);
                    break;
                case "Xml":
                    alumnoBL = new AlumnoBLXml();
                    alumnoBL.Search(nombre, apellidos);
                    break;
                default:
                    break;
            }
        }
    }
}
