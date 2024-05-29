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
    public partial class GraphAddForm : Form
    {
        public GraphAddForm()
        {
            InitializeComponent();
        }       

        private void comboBox1_enter(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Patient;", conn);
            List< KeyValuePair<int,string> > buff = new List<KeyValuePair<int, string>>();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                string buff2 = (string)reader.GetValue(1) + " (" + buff1.ToString() + ")";
                buff.Add(new KeyValuePair<int,string> (buff1, buff2));
            }
            foreach (var i in buff)
            {
                comboBox1.Items.Add(i.Value);
            }
            conn.Close();
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

        private void comboBox3_enter(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Medicine;", conn);
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
                comboBox3.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox1.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("Select * from Patient;", conn);
                MySqlCommand command2 = new MySqlCommand("Select * from Doctor;", conn);
                MySqlCommand command3 = new MySqlCommand("Select * from Medicine;", conn);
                MySqlDataReader reader = command1.ExecuteReader();
                int PatientId = FunctionsBD.GetInt(comboBox1.Text, reader);
                reader = command2.ExecuteReader();
                int DoctorId = FunctionsBD.GetInt(comboBox2.Text, reader);
                reader = command3.ExecuteReader();
                int MedicineId = FunctionsBD.GetInt(comboBox3.Text, reader);
                string query = " INSERT INTO Prescription(PolicyId,doctorID,medicineId,Data_time) " +
                    "Values(" + PatientId + " , " + DoctorId + " , " + MedicineId + ", '" + textBox1.Text+ " ' );";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (PatientId == 0 || DoctorId == 0 || MedicineId == 0)
                {
                    MessageBox.Show("Нет данных для формирования правильного запроса");
                }
                else 
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Экземпляр добавлен");
                }                
                conn.Close();                
            }
            else { MessageBox.Show("Не все поля заполнены!!!"); }
            
            
        }

      
        private void comboBox4_enter(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
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
                comboBox4.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void comboBox5_enter(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
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
                comboBox5.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void comboBox6_enter(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Research;", conn);
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
                comboBox6.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && textBox2.Text != "" && textBox3.Text!="")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("Select * from Patient;", conn);
                MySqlCommand command2 = new MySqlCommand("Select * from Doctor;", conn);
                MySqlCommand command3 = new MySqlCommand("Select * from Research;", conn);
                MySqlDataReader reader = command1.ExecuteReader();
                int PatientId = FunctionsBD.GetInt(comboBox4.Text, reader);
                reader = command2.ExecuteReader();
                int DoctorId = FunctionsBD.GetInt(comboBox5.Text, reader);
                reader = command3.ExecuteReader();
                int ReseachId = FunctionsBD.GetInt(comboBox6.Text, reader);
                
                string query = " INSERT INTO Graph_research(PolicyId,doctorID,researchId,Data_time, result) " +
                    "Values(" + PatientId + " , " + DoctorId + " , " + ReseachId + ", '" + textBox2.Text + " ','"+ textBox3.Text+" ');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (PatientId == 0 || DoctorId == 0 || ReseachId == 0)
                {
                    MessageBox.Show("Нет данных для формирования правильного запроса");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Экземпляр добавлен");
                }
                conn.Close();
                
            }
            else { MessageBox.Show("Не все поля заполнены!!!"); }

        }

        private void comboBox7_enter(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
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
                comboBox7.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void comboBox8_enter(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
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
                comboBox8.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void comboBox9_enter(object sender, EventArgs e)
        {
            comboBox9.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Exam;", conn);
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
                comboBox9.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text != "" && comboBox8.Text != "" && comboBox9.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("Select * from Patient;", conn);
                MySqlCommand command2 = new MySqlCommand("Select * from Doctor;", conn);
                MySqlCommand command3 = new MySqlCommand("Select * from Exam;", conn);
                MySqlDataReader reader = command1.ExecuteReader();
                int PatientId = FunctionsBD.GetInt(comboBox7.Text, reader);
                reader = command2.ExecuteReader();
                int DoctorId = FunctionsBD.GetInt(comboBox8.Text, reader);
                reader = command3.ExecuteReader();
                int ExamId = FunctionsBD.GetInt(comboBox9.Text, reader);

                string query = " INSERT INTO Graph_exam(PolicyId,doctorID,examId,Data_time, result) " +
                    "Values(" + PatientId + " , " + DoctorId + " , " + ExamId + ", '" + textBox4.Text + " ','" + textBox5.Text + " ');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (PatientId == 0 || DoctorId == 0 || ExamId == 0)
                {
                    MessageBox.Show("Нет данных для формирования правильного запроса");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Экземпляр добавлен");
                }
                conn.Close();
               
            }
            else { MessageBox.Show("Не все поля заполнены!!!"); }
        }

        private void comboBox10_enter(object sender, EventArgs e)
        {
            comboBox10.Items.Clear();
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
                comboBox10.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void comboBox11_enter(object sender, EventArgs e)
        {
            comboBox11.Items.Clear();
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
                comboBox11.Items.Add(i.Value);
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox10.Text != "" && comboBox11.Text != "" &&  textBox6.Text != "" && textBox7.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("Select * from Patient;", conn);
                MySqlCommand command2 = new MySqlCommand("Select * from Doctor;", conn);
                
                MySqlDataReader reader = command1.ExecuteReader();
                int PatientId = FunctionsBD.GetInt(comboBox10.Text, reader);
                reader = command2.ExecuteReader();
                int DoctorId = FunctionsBD.GetInt(comboBox11.Text, reader);
                

                string query = " INSERT INTO  Graph_consultation(PolicyId,doctorID,Data_time, result) " +
                    "Values(" + PatientId + " , " + DoctorId  + " , '" + textBox6.Text + " ','" + textBox7.Text + " ');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (PatientId == 0 || DoctorId == 0 )
                {
                    MessageBox.Show("Нет данных для формирования правильного запроса");
                }
                else
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Экземпляр добавлен");
                }
                conn.Close();
               
            }
            else { MessageBox.Show("Не все поля заполнены!!!"); }
        }


    }
}
