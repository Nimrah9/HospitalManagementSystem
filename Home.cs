using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        private void PatientRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            PatientRegistration patientRegistration = new PatientRegistration();
            patientRegistration.Show();
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Billing_Click(object sender, EventArgs e)
        {
            this.Hide();
            Billing billing = new Billing();
            billing.Show();
        }

        private void EmployeeRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmployeeRegistration employee = new EmployeeRegistration();
            employee.Show();
        }
    }
}