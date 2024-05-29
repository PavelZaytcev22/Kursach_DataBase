using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursach_BD
{
    public partial class DeleteForm : Form
    {
        public DeleteForm()
        {
            InitializeComponent();
        }

        private void comboBox1_Enter(object sender, EventArgs e)
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
            if (comboBox1.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                MySqlCommand command = new MySqlCommand("Select * from Patient;", conn);
                MySqlDataReader reader = command.ExecuteReader();
                int index=0;
                while (reader.Read())
                {
                    int buff1 = reader.GetInt32(0);
                    string buff2 = (string)reader.GetValue(1) + " (" + buff1.ToString() + ")";
                    if (comboBox1.Text == buff2) index = buff1;
                }
                reader.Close();
                string query = "Delete from Patient where patient_id="+index+";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);

                if (cmd1.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("!!!!Такого пациента нет!!!");
                }
                else { MessageBox.Show("Пациент удален"); }
                conn.Close();
                comboBox1.Text = "";
                
            }
            else { MessageBox.Show("Поле пустое. Ничего не удалено"); }
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Graph_research;", conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                comboBox2.Items.Add(buff1.ToString());
            }            
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "") 
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                string query = "Delete from Graph_research where research_id=" + comboBox2.Text+ ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                if (cmd1.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("!!!!Такого пациента нет!!!");
                }
                else { MessageBox.Show("Пациент удален"); }
                conn.Close();
                //MessageBox.Show("Пациент удален");
                comboBox2.Text = "";
            }
            else { MessageBox.Show("Поле не заполнено"); }
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Graph_exam;", conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                comboBox3.Items.Add(buff1.ToString());
            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                string query = "Delete from Graph_exam where graph_exam_id=" + comboBox3.Text + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                if (cmd1.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("!!!!Такого пациента нет!!!");
                }
                else { MessageBox.Show("Пациент удален"); }
                conn.Close();
               // MessageBox.Show("Запись удалена");
                comboBox3.Text = "";
            }
            else { MessageBox.Show("Поле не заполнено"); }
        }

        private void comboBox4_Enter(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Graph_consultation;", conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                comboBox4.Items.Add(buff1.ToString());
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                string query = "Delete from Graph_consultation where consultation_id=" + comboBox4.Text + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                if (cmd1.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("!!!!Такого пациента нет!!!");
                }
                else { MessageBox.Show("Пациент удален"); }
                conn.Close();
              //  MessageBox.Show("Запись удалена");
                comboBox4.Text = "";
            }
            else { MessageBox.Show("Поле не заполнено"); }
        }

        private void comboBox5_Enter(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
            conn.Open();
            MySqlCommand command = new MySqlCommand("Select * from Prescription;", conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int buff1 = reader.GetInt32(0);
                comboBox5.Items.Add(buff1.ToString());
            }
            conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=Doctor11;Password=11 ;");
                conn.Open();
                string query = "Delete from Prescription where prescription_id=" + comboBox5.Text + ";";
                MySqlCommand cmd1 = new MySqlCommand(query, conn);
                if (cmd1.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("!!!!Такого пациента нет!!!");
                }
                else { MessageBox.Show("Пациент удален"); }
                conn.Close();
             //   MessageBox.Show("Запись удалена");
                comboBox5.Text = "";
            }
            else { MessageBox.Show("Поле не заполнено"); }
        }

       
    }
}
