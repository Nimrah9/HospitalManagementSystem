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
    public partial class ReceptionistRegistration : Form
    {
        public ReceptionistRegistration()
        {
            InitializeComponent();
        }
        string ename;
        int ephone;
        string eaddress;
        string ejob;
        int esal;
        string etimings;
        string retrievedata;

        public void getdata(string patientid)
        {
            retrievedata = patientid.ToString();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void getemployeedata_Click(object sender, EventArgs e)
        {
            textBox5.Text = retrievedata;
            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command1 = new OleDbCommand("select ephone,ename,eaddress,ejob,esal,etimings from employee where empid = " + textBox5.Text + "", con);
                con.Open();
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    ephone = reader1.GetInt32(3);
                    textBox2.Text = Convert.ToString(ephone);
                    ename = reader1.GetString(1);
                    textBox4.Text = ename;
                    eaddress = reader1.GetString(2);
                    textBox3.Text = Convert.ToString(eaddress);
                    ejob = reader1.GetString(4);
                    textBox1.Text = Convert.ToString(ejob);
                    esal = reader1.GetInt32(5);
                    textBox6.Text = Convert.ToString(esal);
                    etimings = reader1.GetString(6);
                    textBox7.Text = Convert.ToString(etimings);
                }
                reader1.Close();
            }
        }

        private void registerreceptionist_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command = new OleDbCommand("select * from receptionist where receptionistid = '" + textBox5.Text + "'", con);

                con.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    //Insert into database
                    OleDbCommand insertCommand = new OleDbCommand("insert into receptionist (receptionistid,password) values (" + textBox5.Text + ",'" + textBox8.Text + "')", con);
                    try
                    {
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Receptionist registered successfully");
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from  receptionist", con);
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                    catch
                    {
                        MessageBox.Show("An error occured in insertion");
                    }
                }
                else
                {
                    MessageBox.Show("Receptionist is already registered.");
                }
                reader.Close();
            }
        }

        private void ReceptionistRegistration_Load(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                con.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from receptionist", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
      