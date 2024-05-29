using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using MySqlX.XDevAPI.Relational;

namespace Kursach_BD
{
    public partial class Form1 : Form
    {
        Show c1;
        GraphAddForm c2;
        Registration c3;
        DeleteForm c4;
        QueryForm c5;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (c1 != null) { c1.Close(); }
            c1 = new Show();
            c1.Show(); 




            /*MySqlConnection conn = new MySqlConnection("Database=kursach; Server=localhost;User=User111;Password=111 ;");
            conn.Open();
            if (conn.State==System.Data.ConnectionState.Open) { MessageBox.Show(conn.Database); }
            DataTable table = new DataTable();
            MySqlDataAdapter buff = new MySqlDataAdapter("Select * from Doctor;",conn);
            buff.Fill(table);
           // dataGridView1.DataSource = table;
            MySqlCommand command = new MySqlCommand("Select * from Doctor;",conn);
            DataTable table2 = new DataTable("table");
            table2.Columns.Add("ID",typeof(string));
            table2.Columns.Add("Врач", typeof(string));
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {                
                table2.Rows.Add(reader.GetValue(0), reader.GetValue(1));
            }
            reader.Close();
            
            dataGridView1.DataSource = table2;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c2 != null) { c2.Close(); }
            c2 = new GraphAddForm();
            c2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (c3 != null) { c3.Close(); }
            c3 = new Registration();
            c3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (c4 != null) { c4.Close(); }
            c4 = new DeleteForm();
            c4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (c5 != null) { c5.Close(); }
            c5 = new QueryForm();
            c5.Show();
        }
    }
}
