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
    public partial class PatientRegistration : Form
    {
        public PatientRegistration()
        {
            InitializeComponent();
        }
        string patientid;
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
                OleDbCommand command = new OleDbCommand("select * from patient where patientid = '" + textBox5.Text + "'", con);

                con.Open();
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows == false)
                {
                    //Insert into database
                    OleDbCommand insertCommand = new OleDbCommand("insert into patient (patientid, pname, paddress, pnumber,pstatus) values (" + textBox5.Text + ",'" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox1.Text + "')", con);
                    try
                    {
                        insertCommand.ExecuteNonQuery();
                        MessageBox.Show("Patient registered successfully");
                        DataTable dt = new DataTable();
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from  patient", con);
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

        private void retrievepatientid_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Walkin")
            {
                this.Hide();
                WalkinPatient walkin = new WalkinPatient();
                walkin.getdata(patientid.ToString());
                walkin.Show();
            }
            else if (textBox1.Text == "Appointment")
            {
                this.Hide();
                AppointmentPatient appointment = new AppointmentPatient();
                appointment.getdata(patientid.ToString());
                appointment.Show();
            }
            else if (textBox1.Text == "Admit")
            {
                this.Hide();
                AdmitPatient admit = new AdmitPatient();
                admit.getdata(patientid.ToString());
                admit.Show();
            }
        }

        private void PatientRegistration_Load(object sender, EventArgs e)
        {
            using (OleDbConnection con = new OleDbConnection())
            {
                con.Open();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter("select * from patient", con);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}