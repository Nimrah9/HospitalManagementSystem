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
    public partial class AdmitPatient : Form
    {
        public AdmitPatient()
        {
            InitializeComponent();
        }
        string retrievedata;
        string pname;
        string paddress;
        int pphone;
        string pstatus;

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

        private void getpatientdata_Click(object sender, EventArgs e)
        {
            textBox1.Text = retrievedata;
            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command1 = new OleDbCommand("select pphone,pname,paddress,pstatus from patient where patientid = " + textBox1.Text + "", con);
                con.Open();
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    pphone = reader1.GetInt32(3);
                    textBox3.Text = Convert.ToString(pphone);

                    pname = reader1.GetString(1);
                    textBox2.Text = pname;

                    paddress = reader1.GetString(2);
                    textBox4.Text = paddress;

                    pstatus = reader1.GetString(4);
                    textBox5.Text = pstatus;
                }
                reader1.Close();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            int timings;
            string dname;

            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command2 = new OleDbCommand("select timings,ename from employee where empid ='" + textBox7.Text + "'", con);
                con.Open();
                OleDbDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    timings = reader2.GetInt32(6);
                    textBox3.Text = Convert.ToString(timings);
                    dname = reader2.GetString(1);
                    textBox4.Text = dname;
                    reader2.Close();
                }
            }
        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            int timings;
            string nname;

            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command2 = new OleDbCommand("select timings,ename from employee where empid ='" + textBox14.Text + "'", con);
                con.Open();
                OleDbDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    timings = reader2.GetInt32(6);
                    textBox16.Text = Convert.ToString(timings);
                    nname = reader2.GetString(1);
                    textBox15.Text = nname;
                    reader2.Close();
                }
            }
        }
        private void Register_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command = new OleDbCommand("select * from admitpatient where admitpatientid = '" + textBox1.Text + "'", con);

                con.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    //Insert into database
                    OleDbCommand insertCommand = new OleDbCommand("insert into admitpatient (admitpatientid, doctorid,dateofadmission,dateofdischarge,patientdetails,roomcharges,duration,nurseid) values (" + textBox1.Text + ",'" + textBox7.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox10.Text + "','"+ textBox6.Text +"','"+ textBox11.Text +"','"+ textBox14.Text +"')", con);
                    try
                    {
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Patient registered successfully");
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from  admitpatient", con);
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
                    MessageBox.Show("Patient is already registered.");
                }
                reader.Close();
            }
        
        }

        private void AdmitPatient_Load(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                con.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from admitpatient", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
