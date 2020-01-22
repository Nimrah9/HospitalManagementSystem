namespace WindowsFormsApplication1
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PatientRegistration = new System.Windows.Forms.Button();
            this.EmployeeRegistration = new System.Windows.Forms.Button();
            this.Billing = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PatientRegistration
            // 
            this.PatientRegistration.Location = new System.Drawing.Point(293, 83);
            this.PatientRegistration.Name = "PatientRegistration";
            this.PatientRegistration.Size = new System.Drawing.Size(132, 42);
            this.PatientRegistration.TabIndex = 0;
            this.PatientRegistration.Text = "Patient Registration";
            this.PatientRegistration.UseVisualStyleBackColor = true;
            this.PatientRegistration.Click += new System.EventHandler(this.PatientRegistration_Click);
            // 
            // EmployeeRegistration
            // 
            this.EmployeeRegistration.Location = new System.Drawing.Point(293, 165);
            this.EmployeeRegistration.Name = "EmployeeRegistration";
            this.EmployeeRegistration.Size = new System.Drawing.Size(132, 46);
            this.EmployeeRegistration.TabIndex = 1;
            this.EmployeeRegistration.Text = "Employee Registration";
            this.EmployeeRegistration.UseVisualStyleBackColor = true;
            this.EmployeeRegistration.Click += new System.EventHandler(this.EmployeeRegistration_Click);
            // 
            // Billing
            // 
            this.Billing.Location = new System.Drawing.Point(293, 242);
            this.Billing.Name = "Billing";
            this.Billing.Size = new System.Drawing.Size(132, 39);
            this.Billing.TabIndex = 3;
            this.Billing.Text = "Billing";
            this.Billing.UseVisualStyleBackColor = true;
            this.Billing.Click += new System.EventHandler(this.Billing_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(293, 302);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(132, 65);
            this.Exit.TabIndex = 4;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 418);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.Billing);
            this.Controls.Add(this.EmployeeRegistration);
            this.Controls.Add(this.PatientRegistration);
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PatientRegistration;
        private System.Windows.Forms.Button EmployeeRegistration;
        private System.Windows.Forms.Button Billing;
        private System.Windows.Forms.Button Exit;
    }
}