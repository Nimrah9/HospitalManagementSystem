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
    public partial class EmployeeRegistration : Form
    {
        public EmployeeRegistration()
        {
            InitializeComponent();
        }
        string empid;

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.Show();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                OleDbCommand command = new OleDbCommand("select * from employee where empid = '" + textBox5.Text + "'", con);

                con.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    //Insert into database
                    OleDbCommand insertCommand = new OleDbCommand("insert into employee (empid, ename, eaddress, enumber,ejob,esal,etimings) values (" + textBox5.Text + ",'" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", con);
                    try
                    {
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Employee registered successfully");
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from  employee", con);
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
                    MessageBox.Show("Employee is already registered.");
                }
        }

                reader.Close();
            }
        private void EmployeeRegistration_Load(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                con.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from employee", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void retrievepatientid_Click_1(object sender, EventArgs e)
        {
            textBox5.Text = empid;
            if (textBox1.Text == "Doctor")
            {
                this.Hide();
                DoctorRegistration doctor = new DoctorRegistration();
                doctor.getdata(empid.ToString());
                doctor.Show();
            }
            else if (textBox1.Text == "Nurse")
            {
                this.Hide();
                NurseRegistration nurse = new NurseRegistration();
                nurse.getdata(empid.ToString());
                nurse.Show();
            }
            else if (textBox1.Text == "Receptionist")
            {
                this.Hide();
                ReceptionistRegistration receptionist = new ReceptionistRegistration();
                receptionist.getdata(empid.ToString());
                receptionist.Show();
            }
        }

    }
}

