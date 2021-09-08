using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WFA_GradesRecord.Entity;

namespace WFA_GradesRecord
{
    public partial class Form1 : Form
    {
        //Creamos un diccionario para guardar objetos alumno
        Dictionary<int, Alumn> diccionario = new Dictionary<int, Alumn>();

        public Form1()
        {
            InitializeComponent();

            //Custom
            LoadDGVColumns();
            LoadCboCourses();
            grpData.Enabled = false;
        }

        private void LoadCboCourses()
        {
            string[] cursos = new string[] { "Matemáticas", "Física", "Química", "Historia" };
            cboCourses.DataSource = cursos;
            cboCourses.SelectedIndex = -1;
        }

        private void LoadDGVColumns()
        {
            dgvReport.Columns.Clear();

            dgvReport.Columns.Add("numero", "ID");
            dgvReport.Columns.Add("alumno", "Alumn");
            dgvReport.Columns.Add("curso", "Course");
            dgvReport.Columns.Add("N1", "N1");
            dgvReport.Columns.Add("N2", "N2");
            dgvReport.Columns.Add("N3", "N3");
            dgvReport.Columns.Add("promedio", "Average");
            dgvReport.Columns.Add("aprobado", "Approved");

            dgvReport.Columns[0].Width = 35;
            dgvReport.Columns[1].Width = 150;
            dgvReport.Columns[2].Width = 150;
            dgvReport.Columns[3].Width = 40;
            dgvReport.Columns[4].Width = 40;
            dgvReport.Columns[5].Width = 40;
            dgvReport.Columns[6].Width = 100;
            dgvReport.Columns[7].Width = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void LoadGridReport()
        {
            int fila = 0;
            //limpiar la grilla
            dgvReport.Rows.Clear();
            foreach (KeyValuePair<int, Alumn> clave in diccionario)
            {
                //Creamos una fila nueva
                dgvReport.Rows.Add();
                dgvReport.Rows[fila].Cells[0].Value = clave.Value.Numero;
                dgvReport.Rows[fila].Cells[1].Value = clave.Value.Nombre;
                dgvReport.Rows[fila].Cells[2].Value = clave.Value.Curso;
                dgvReport.Rows[fila].Cells[3].Value = clave.Value.N1;
                dgvReport.Rows[fila].Cells[4].Value = clave.Value.N2;
                dgvReport.Rows[fila].Cells[5].Value = clave.Value.N3;
                dgvReport.Rows[fila].Cells[6].Value = clave.Value.NotaFinal;
                dgvReport.Rows[fila].Cells[7].Value = clave.Value.Estado;
                fila += 1;
            }
        }

        private void Limpiar()
        {
            txtId.Clear();
            cboCourses.SelectedIndex = -1;
            txtScore1.Clear();
            txtScore2.Clear();
            txtScore3.Clear();
            txtName.Clear();
            //txtPromedio.Clear();
            //rbtAprobado.Checked = false;
            //rbtDesaprobado.Checked = false;
        }

        private void GeneraCodigo()
        {
            int cantFilas = dgvReport.RowCount;
            // txtNumero.Text = (cantFilas + 1).ToString();
            txtId.Text = (cantFilas).ToString();
            txtId.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (Alumn alumno = new Alumn())
            {
                //Creamos una instancia de la clase alumno
                alumno.Numero = Convert.ToInt32(txtId.Text);
                alumno.Nombre = txtName.Text;
                alumno.Curso = cboCourses.Text;
                alumno.N1 = Convert.ToInt32(txtScore1.Text);
                alumno.N2 = Convert.ToInt32(txtScore2.Text);
                alumno.N3 = Convert.ToInt32(txtScore3.Text);
                //Agregar la clase a la coleccion
                diccionario.Add(alumno.Numero, alumno);
                //Mostramos los registros de alumnos en la grilla
                LoadGridReport();
                grpData.Enabled = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Limpiar();
            GeneraCodigo();
            grpData.Enabled = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string idSearch = Util.MsgBox("Buscar Alumno", "Ingrese el codigo");
            int numero = Convert.ToInt32(idSearch);
            //Buscar a un alumno en el diccionario por su numero
            //con el metodo ContanisKey devuelve true(encontrado)  o false (no encontrado)
            if (diccionario.ContainsKey(numero))
            {
                txtId.Text = diccionario[numero].Numero.ToString();
                txtName.Text = diccionario[numero].Nombre;
                cboCourses.Text = diccionario[numero].Curso;
                txtScore1.Text = diccionario[numero].N1.ToString();
                txtScore2.Text = diccionario[numero].N2.ToString();
                txtScore3.Text = diccionario[numero].N3.ToString();
                // txtPromedio.Text = diccionario[numero].NotaFinal.ToString();

                //if (diccionario[numero].Estado == true)
                //{ rbtAprobado.Checked = true; }
                //else { rbtDesaprobado.Checked = true; }
                //Cancelamos la busqueda
            }
            else
            {
                MessageBox.Show("No existe");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string idSearch = Util.MsgBox("Eliminar Alumno", "Ingrese el codigo");
            int numero = Convert.ToInt32(idSearch);
            //Buscar a un alumno en el diccionario por su numero
            //con el metodo ContanisKey devuelve true(encontrado)  o false (no encontrado)
            if (diccionario.ContainsKey(numero))
            {
                //Eliminar al alumno por su clave
                diccionario.Remove(numero);
                LoadGridReport();
            }
            else
            {
                MessageBox.Show("No existe");
            }


        }


        //private void dgvAlumns_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{


        //    DataGridViewRow Fila = dgvReport.CurrentRow;

        //    int codigo = Convert.ToInt32(Fila.Cells["numero"].Value);

        //    Alumn al = new Alumn();
        //    al.Numero = codigo;
        //    al.Nombre = Fila.Cells["alumno"].Value.ToString();
        //    al.Curso = Fila.Cells["curso"].Value.ToString();
        //    al.N1 = Convert.ToInt32(Fila.Cells["N1"].Value);
        //    al.N2 = Convert.ToInt32(Fila.Cells["N2"].Value);
        //    al.N3 = Convert.ToInt32(Fila.Cells["N3"].Value);

        //    diccionario[codigo] = al;
        //    LoadGridReport();

        //}
    }
}
