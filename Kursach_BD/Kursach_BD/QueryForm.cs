using MySql.Data.MySqlClient;
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
    public partial class QueryForm : Form
    {
        public QueryForm()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;
        }

        private void comboBox1_enter(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Patient;", conn);
            List<KeyValuePair<int, string>> buff = new List<KeyValuePair<int, string>>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                string buff2 = (string)reader.GetValue(1) + " (" + buff1.ToString() + ")";
                buff.Add(new KeyValuePair<int, string>(buff1, buff2));
            }
            foreach (var i in buff)
            {
                comboBox1.Items.Add(i.Value);
            }
            conn.Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!="")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("Select Graph_research.Data_time as 'Дата/время', Patient.patient_id as 'id' , Patient.patient_name as 'Пациент', Doctor.doctor_name as 'Доктор', Research.research_name as 'Процедура', " +
                    " result as 'Результат' from Graph_research " +
                    " join Patient on Patient.patient_id=PolicyId " +
                    " join Doctor on Doctor.doctor_id= doctorId " +
                    " join Research on Research.research_id=researchId; ", conn);
                MySqlCommand command2 = new MySqlCommand("Select Graph_exam.Data_time as 'Дата/время', Patient.patient_id as 'id' , Patient.patient_name as 'Пациент', Doctor.doctor_name as 'Доктор', Exam.exam_name as 'Процедура', " +
                    " result as 'Результат' from Graph_exam " +
                    " join Patient on Patient.patient_id=PolicyId " +
                    " join Doctor on Doctor.doctor_id= doctorId " +
                    " join Exam on Exam.exam_id=examId; ", conn);
                MySqlCommand command3 = new MySqlCommand("Select Prescription.Data_time as 'Дата/время', Patient.patient_id as 'id' , Patient.patient_name as 'Пациент', Doctor.doctor_name as 'Доктор', Medicine.medicine_name as 'Процедура' " +
                    "  from Prescription " +
                    " join Patient on Patient.patient_id=PolicyId " +
                    " join Doctor on Doctor.doctor_id= doctorId " +
                    " join Medicine on Medicine.medicine_id=medicineId; ", conn);
                MySqlCommand command4 = new MySqlCommand(" Select Graph_consultation.Data_time as 'Дата/время', Patient.patient_id as 'id' , Patient.patient_name as 'Пациент', Doctor.doctor_name as 'Доктор', result as 'Результат' " +
                    "  from Graph_consultation " +
                    " join Patient on Patient.patient_id=PolicyId " +
                    " join Doctor on Doctor.doctor_id= doctorId; " , conn);
                DataTable datatable = new DataTable();
                datatable.Columns.Add("Дата/вермя",typeof(string));
                datatable.Columns.Add("Доктор", typeof(string));
                datatable.Columns.Add("Процедура/лекарство", typeof(string));
                datatable.Columns.Add("Название события", typeof(string));
                datatable.Columns.Add("Результат", typeof(string));
                MySqlDataReader reader = command1.ExecuteReader();
                while (reader.Read()) 
                {
                    string buff1 = (string)reader.GetValue(2) + " (" + reader.GetValue(1) + ")";
                    if (comboBox1.Text == buff1) 
                    {
                        string buffdata = reader.GetString(0);
                        string buffdoctor = reader.GetString(3);
                        string buffname = reader.GetString(4);
                        string buffres;
                        if (reader.GetValue(5) is System.DBNull)
                        {
                            buffres = "";
                        }
                        else { buffres = (string)reader.GetValue(5); }
                        
                        datatable.Rows.Add(buffdata, buffdoctor,buffname,"Исследование ", buffres);
                    }
                }
                reader.Close();
                reader = command2.ExecuteReader();
                while (reader.Read())
                {
                    string buff1 = (string)reader.GetValue(2) + " (" + reader.GetValue(1) + ")";
                    if (comboBox1.Text == buff1)
                    {
                        string buffdata = reader.GetString(0);
                        string buffdoctor = reader.GetString(3);
                        string buffname = reader.GetString(4);
                        string buffres;
                        if (reader.GetValue(5) is System.DBNull)
                        {
                            buffres = "";
                        }
                        else { buffres = (string)reader.GetValue(5); }

                        datatable.Rows.Add(buffdata, buffdoctor, buffname, "Обследование", buffres);
                    }
                }
                reader.Close();
                reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    string buff1 = (string)reader.GetValue(2) + " (" + reader.GetValue(1) + ")";
                    if (comboBox1.Text == buff1)
                    {
                        string buffdata = reader.GetString(0);
                        string buffdoctor = reader.GetString(3);
                        string buffname = reader.GetString(4);        
                        datatable.Rows.Add(buffdata, buffdoctor, buffname, "Рецепт","-");
                    }
                }
                reader.Close();
                reader = command4.ExecuteReader();
                while (reader.Read())
                {
                    string buff1 = (string)reader.GetValue(2) + " (" + reader.GetValue(1) + ")";
                    if (comboBox1.Text == buff1)
                    {
                        string buffdata = reader.GetString(0);
                        string buffdoctor = reader.GetString(3);
                        string buffres;
                        if (reader.GetValue(4) is System.DBNull)
                        {
                            buffres = "";
                        }
                        else { buffres = (string)reader.GetValue(4); }
                        datatable.Rows.Add(buffdata, buffdoctor, "Консультация", "Консультация", buffres);
                    }
                }
                reader.Close();
                dataGridView1.DataSource = datatable;
                dataGridView1.AutoResizeColumns();
            }
            else
            {
                MessageBox.Show("Выбирите пациента");
            }
        }

        private void comboBox2_enter(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Doctor;", conn);
            List<KeyValuePair<int, string>> buff = new List<KeyValuePair<int, string>>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                string buff2 = (string)reader.GetValue(1) + " (" + buff1.ToString() + ")";
                buff.Add(new KeyValuePair<int, string>(buff1, buff2));
            }
            foreach (var i in buff)
            {
                comboBox2.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "" && comboBox3.Text != "")
            {
                DataTable dt = new DataTable();

                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("SELECT PolicyId, PATIENT.patient_name, doctorId, DOctor.doctor_name from Graph_consultation " +
                    " join Patient on Patient.patient_id=PolicyId " +
                    "join Doctor on DOctor.doctor_id=doctorId;", conn);
                MySqlCommand command2 = new MySqlCommand("SELECT PolicyId, PATIENT.patient_name, doctorId, DOctor.doctor_name from Graph_exam " +
                    " join Patient on Patient.patient_id=PolicyId " +
                    " join Doctor on Doctor.doctor_id=doctorId;", conn);
                MySqlCommand command3 = new MySqlCommand("SELECT PolicyId, PATIENT.patient_name, doctorId, DOctor.doctor_name from Graph_research " +
                    " join Patient on Patient.patient_id=PolicyId " +
                    " join Doctor on DOctor.doctor_id=doctorId;", conn);
                MySqlCommand command4 = new MySqlCommand("SELECT PolicyId, PATIENT.patient_name, doctorId, DOctor.doctor_name from Prescription" +
                    " join Patient on Patient.patient_id=PolicyId " +
                    "join Doctor on DOctor.doctor_id=doctorId;", conn);
                switch (comboBox3.Text) 
                {

                    case "Пациенты":
                        dt.Columns.Add("Пациенты",typeof(string));

                        HashSet<string> set = new HashSet<string>();
                        MySqlDataReader reader = command1.ExecuteReader();
                        while (reader.Read()) 
                        {
                        int c1 = reader.GetInt32(0);
                        int c2 = reader.GetInt32(2);
                        string buff1= (string)reader.GetValue(1) + " (" + c1.ToString() + ")"; 
                        string buff2= (string)reader.GetValue(3) + " (" + c2.ToString() + ")";
                            if (buff2 == comboBox2.Text) { set.Add(buff1);}
                        }
                        reader.Close();
                        reader = command2.ExecuteReader();
                        while (reader.Read())
                        {
                            int c1 = reader.GetInt32(0);
                            int c2 = reader.GetInt32(2);
                            string buff1 = (string)reader.GetValue(1) + " (" + c1.ToString() + ")";
                            string buff2 = (string)reader.GetValue(3) + " (" + c2.ToString() + ")";
                            if(buff2 == comboBox2.Text) { set.Add(buff1); }
                        }
                        reader.Close();
                        reader = command3.ExecuteReader();
                        while (reader.Read())
                        {
                            int c1 = reader.GetInt32(0);
                            int c2 = reader.GetInt32(2);
                            string buff1 = (string)reader.GetValue(1) + " (" + c1.ToString() + ")";
                            string buff2 = (string)reader.GetValue(3) + " (" + c2.ToString() + ")";
                            if (buff2 == comboBox2.Text) { set.Add(buff1); }
                        }
                        reader.Close();
                        reader = command4.ExecuteReader();
                        while (reader.Read())
                        {
                            int c1 = reader.GetInt32(0);
                            int c2 = reader.GetInt32(2);
                            string buff1 = (string)reader.GetValue(1) + " (" + c1.ToString() + ")";
                            string buff2 = (string)reader.GetValue(3) + " (" + c2.ToString() + ")";
                            if (buff2 == comboBox2.Text) { set.Add(buff1); }
                        }
                        reader.Close();
                        foreach (string i in set) 
                        {
                            dt.Rows.Add(i);
                        }
                        dataGridView2.DataSource = dt;
                        dataGridView2.AutoResizeColumns();
                        break;

                    case "Лекарства":
                        dt.Columns.Add("Лекарство",typeof(string));
                        dt.Columns.Add("Пациент", typeof(string));
                        dt.Columns.Add("Время", typeof(string));
                        MySqlCommand commandMed = new MySqlCommand("SELECT medicineId, Medicine.medicine_name, doctorId, DOctor.doctor_name, Data_time, Patient.patient_name from Prescription  " +
                    " join Medicine on Medicine.medicine_id=medicineId " +
                    " join Doctor on DOctor.doctor_id=doctorId " +
                    " join Patient on Patient.patient_id=PolicyId; ", conn);
                        
                        MySqlDataReader reader1 = commandMed.ExecuteReader();
                        while (reader1.Read())
                        {
                            int c1 = reader1.GetInt32(0);
                            int c2 = reader1.GetInt32(2);
                            string buff1 = (string)reader1.GetValue(1) + " (" + c1.ToString() + ")";
                            string buff2 = (string)reader1.GetValue(3) + " (" + c2.ToString() + ")";
                            string buff3;
                            string buff4;
                            if (reader1.GetValue(5) is System.DBNull)
                            {
                                buff3 = "";
                            }
                            else { buff3 = (string)reader1.GetValue(5); }
                            if (reader1.GetValue(4) is System.DBNull)
                            {
                                buff4 = "";
                            }
                            else { buff4 = (string)reader1.GetValue(4); }
                            if (buff2 == comboBox2.Text)
                            {
                                dt.Rows.Add(buff1,buff3,buff4);
                            }
                        }
                        reader1.Close();
                        
                        dataGridView2.DataSource = dt;
                        dataGridView2.AutoResizeColumns();
                        break;

                    case "Исследования ":
                        dt.Columns.Add("Исследование", typeof(string));
                        dt.Columns.Add("Пациент", typeof(string));
                        dt.Columns.Add("Время", typeof(string));
                        MySqlCommand commandRes = new MySqlCommand("SELECT researchId, Research.research_name, doctorId, Doctor.doctor_name, Data_time, Patient.patient_name from Graph_research  " +
                   " join Research on Research.research_id=researchId " +
                   "join Doctor on DOctor.doctor_id=doctorId " +
                   " join Patient on Patient.patient_id=PolicyId; ", conn);

                        MySqlDataReader reader2 = commandRes.ExecuteReader();
                        while (reader2.Read())
                        {
                            int c1 = reader2.GetInt32(0);
                            int c2 = reader2.GetInt32(2);
                            string buff1 = (string)reader2.GetValue(1) + " (" + c1.ToString() + ")";
                            string buff2 = (string)reader2.GetValue(3) + " (" + c2.ToString() + ")";
                            string buff3;
                            string buff4;
                            if (reader2.GetValue(5) is System.DBNull)
                            {
                                buff3 = "";
                            }
                            else { buff3 = (string)reader2.GetValue(5); }
                            if (reader2.GetValue(4) is System.DBNull)
                            {
                                buff4 = "";
                            }
                            else { buff4 = (string)reader2.GetValue(4); }
                            if (buff2 == comboBox2.Text)
                            {
                                dt.Rows.Add(buff1, buff3, buff4);
                            }
                        }
                        reader2.Close();

                        dataGridView2.DataSource = dt;
                        dataGridView2.AutoResizeColumns();

                        break;

                    case "Обследования":
                        dt.Columns.Add("Обследование", typeof(string));
                        dt.Columns.Add("Пациент", typeof(string));
                        dt.Columns.Add("Время", typeof(string));
                        MySqlCommand commandEx = new MySqlCommand("SELECT examId, Exam.exam_name, doctorId, Doctor.doctor_name, Data_time, Patient.patient_name from Graph_exam  " +
                   " join Exam on Exam.exam_id=examId " +
                   "join Doctor on DOctor.doctor_id=doctorId " +
                   " join Patient on Patient.patient_id=PolicyId; ", conn);

                        MySqlDataReader reader3 = commandEx.ExecuteReader();
                        while (reader3.Read())
                        {
                            int c1 = reader3.GetInt32(0);
                            int c2 = reader3.GetInt32(2);
                            string buff1 = (string)reader3.GetValue(1) + " (" + c1.ToString() + ")";
                            string buff2 = (string)reader3.GetValue(3) + " (" + c2.ToString() + ")";
                            string buff3;
                            string buff4;
                            if (reader3.GetValue(5) is System.DBNull)
                            {
                                buff3 = "";
                            }
                            else { buff3 = (string)reader3.GetValue(5); }
                            if (reader3.GetValue(4) is System.DBNull)
                            {
                                buff4 = "";
                            }
                            else { buff4 = (string)reader3.GetValue(4); }
                            if (buff2 == comboBox2.Text)
                            {
                                dt.Rows.Add(buff1, buff3, buff4);
                            }
                        }
                        reader3.Close();

                        dataGridView2.DataSource = dt;
                        dataGridView2.AutoResizeColumns();
                        break;                
                }
            }
            else { MessageBox.Show("Не все поля заполнены"); }
        }
    }
}
