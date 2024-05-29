using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach_BD
{
    public partial class Show : Form
    {
        public Show()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.ReadOnly = true;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.ReadOnly = true;
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.ReadOnly = true;
            dataGridView6.AllowUserToAddRows = false;
            dataGridView6.ReadOnly = true;
            dataGridView7.AllowUserToAddRows = false;
            dataGridView7.ReadOnly = true;
            dataGridView8.AllowUserToAddRows = false;
            dataGridView8.ReadOnly = true;
            dataGridView9.AllowUserToAddRows = false;
            dataGridView9.ReadOnly = true;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();

            MySqlCommand command = new MySqlCommand("Select * from Doctor;", conn);
            DataTable table2 = new DataTable("table");
            table2.Columns.Add("ID", typeof(string));
            table2.Columns.Add("Врач", typeof(string));
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                table2.Rows.Add(reader.GetValue(0),reader.GetValue(1));
            }
            dataGridView1.DataSource = table2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();

            MySqlCommand command = new MySqlCommand("Select * from Research;", conn);
            DataTable table2 = new DataTable("table");
            table2.Columns.Add("ID", typeof(string));
            table2.Columns.Add("Исследование", typeof(string));
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                table2.Rows.Add(reader.GetValue(0), reader.GetValue(1));
            }
            dataGridView2.DataSource = table2;
            dataGridView2.AutoResizeColumn(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11;");
            conn.Open();

            MySqlCommand command = new MySqlCommand("Select * from Medicine;", conn);
            DataTable table2 = new DataTable("table");
            table2.Columns.Add("ID", typeof(string));
            table2.Columns.Add("Исследование", typeof(string));
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                table2.Rows.Add(reader.GetValue(0), reader.GetValue(1));
            }
            dataGridView3.DataSource = table2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();

            MySqlCommand command = new MySqlCommand("Select * from Exam;", conn);
            DataTable table2 = new DataTable("table");
            table2.Columns.Add("ID", typeof(string));
            table2.Columns.Add("Обследование", typeof(string));
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                table2.Rows.Add(reader.GetValue(0), reader.GetValue(1));
            }
            dataGridView4.DataSource = table2;
            dataGridView4.AutoResizeColumn(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");

            conn.Open();

            MySqlCommand command = new MySqlCommand("Select * from Patient;", conn);
            DataTable table2 = new DataTable("table");
            table2.Columns.Add("ID", typeof(string));
            table2.Columns.Add("ФИО", typeof(string));
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                table2.Rows.Add(reader.GetValue(0), reader.GetValue(1));
            }
            dataGridView5.DataSource = table2;
            dataGridView5.AutoResizeColumn(1);
        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11;");
            conn.Open();
            string command = "Select consultation_id as 'Id',  Patient.patient_name as 'Пициент', Doctor.doctor_name as 'Врач',  Graph_consultation.Data_time as 'Время/Дата', Graph_consultation.result as 'Результат' from Graph_consultation " +
          "join Patient ON Patient.patient_id=PolicyId join Doctor ON Doctor.doctor_id=Graph_consultation.doctorId ";
            //MySqlCommand command = new MySqlCommand("", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
            DataTable table2 = new DataTable("table");
            adapter.Fill(table2);
            conn.Close();
            dataGridView6.DataSource = table2;
            dataGridView6.AutoResizeColumns();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11;");
            conn.Open();
            string command = "Select Graph_research.research_id as 'Id', Patient.patient_name as 'Пициент', Doctor.doctor_name as 'Врач', Research.research_name as 'Исследование', Graph_research.Data_time as 'Время/Дата', Graph_research.result as 'Результат' from Graph_research " +
                "join Patient ON Patient.patient_id=PolicyId join Doctor ON Doctor.doctor_id=doctorId join Research On Research.research_id=researchId; ";
            //MySqlCommand command = new MySqlCommand("", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
            DataTable table2 = new DataTable("table");
            adapter.Fill(table2);
            conn.Close();
            dataGridView7.DataSource = table2;
            dataGridView7.AutoResizeColumns();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11;");
            conn.Open();
            string command = "Select Graph_exam.graph_exam_id as 'Id', Patient.patient_name as 'Пициент', Doctor.doctor_name as 'Врач', Exam.exam_name as 'Обследование', Graph_exam.Data_time as 'Время/Дата', Graph_exam.result as 'Результат' from Graph_exam " +
                "join Patient ON Patient.patient_id=PolicyId join Doctor ON Doctor.doctor_id=Graph_exam.doctorId join Exam On Exam.exam_id=Graph_exam.examId; ";
            //MySqlCommand command = new MySqlCommand("", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command,conn);
            DataTable table2 = new DataTable("table");
            adapter.Fill(table2);
            conn.Close();
            dataGridView8.DataSource = table2;
            dataGridView8.AutoResizeColumns();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11;");
            conn.Open();
            string command = "Select Prescription.prescription_id as 'Id', Patient.patient_name as 'Пициент', Doctor.doctor_name as 'Врач', Medicine.medicine_name as 'Препарат', Prescription.Data_time as 'Время/Дата' from Prescription " +
                "join Patient ON Patient.patient_id=PolicyId join Doctor ON Doctor.doctor_id=Prescription.doctorId join Medicine On Medicine.medicine_id=Prescription.medicineId; ";
            //MySqlCommand command = new MySqlCommand("", conn);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command, conn);
            DataTable table2 = new DataTable("table");
            adapter.Fill(table2);
            conn.Close();
            dataGridView9.DataSource = table2;
            dataGridView9.AutoResizeColumns();
        }
    }
}
