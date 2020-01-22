using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command = new OleDbCommand("select * from receptionist where receptionistid = '" + textBox1.Text + "' and password = '" + textBox2.Text + "'", con);

                con.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    MessageBox.Show("Invalid userId or password. Please try againjt.");
                }
                else
                {
                    this.Hide();
                    Home f2 = new Home();
                    f2.Show();
                }
                reader.Close();
            }
        }
    }
}