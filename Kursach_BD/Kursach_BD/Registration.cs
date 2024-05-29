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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursach_BD
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=User11;Password=11 ;");
                conn.Open();
                string query = " INSERT INTO Patient (patient_name) values( '" +
                    textBox1.Text+"');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Вы зарегистрировались");
            }
            else { MessageBox.Show("Поле пусто"); }
        }
    }
}
