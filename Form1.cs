using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MoansoPrototipo.Form1;

namespace MoansoPrototipo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Empleado
        {
            public string Nombre { get; set; }
            public string Dni { get; set; }
            public string Faltas { get; set; }
            public decimal Sueldo { get; set; }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtSueldo.Text) || cmbFaltas.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            string nombre = txtNombre.Text;
            string dni = txtDni.Text;
            string faltas = cmbFaltas.SelectedItem.ToString(); 
            decimal sueldo = decimal.Parse(txtSueldo.Text);    

           
            if (faltas == "Si")
            {
                sueldo -= sueldo * 0.10m; 
            }

            empleados.Add(new Empleado { Nombre = nombre, Dni = dni, Faltas = faltas, Sueldo = sueldo });

            dataGridView1.DataSource = null; 
            dataGridView1.DataSource = empleados;
            LimpiarCampos();
        }
        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtSueldo.Text = string.Empty;
            cmbFaltas.SelectedIndex = -1;
        }
        List<Empleado> empleados = new List<Empleado>();
    }
}
