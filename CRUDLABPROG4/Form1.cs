using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace CRUDLABPROG4
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1Guardar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=MISTHERG ; database=LabProg ; integrated security = true");
            conexion.Open();
            string matricula = textBoxMatricula.Text;
            string nombre = textBoxNombre.Text;
            string cadena = "insert into Crud(matricula,nombre) values (" + matricula + ",'" + nombre + "')";
            SqlCommand comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");
            textBoxMatricula.Text = "";
            textBoxNombre.Text = "";
            conexion.Close();
        }

        private void button2Consulta_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server=MISTHERG ; database=LabProg ; integrated security = true");
            conexion.Open();
            string matricula = textBoxMatricula.Text;
            string cadena = "select nombre from Crud where matricula=" + matricula;
            SqlCommand comando = new SqlCommand(cadena, conexion);
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                textBoxNombre.Text = registro["nombre"].ToString();
                
            }
            else
                MessageBox.Show("No existe un estudiante con la matricula ingresada");
            conexion.Close();
        }
    }
}
