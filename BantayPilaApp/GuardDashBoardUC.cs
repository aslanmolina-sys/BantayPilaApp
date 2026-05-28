using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace BantayPilaApp
{
    public partial class GuardDashboardUC : UserControl
    {
        public GuardDashboardUC()
        {
            InitializeComponent();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
         
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || cmbGender.SelectedItem == null || cmbPriority.SelectedItem == null)
            {
                MessageBox.Show("Please fill out Name, Gender, and Priority!", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            string connString = "Data Source=bantaypila.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();

            
                    string insertPatientQuery = "INSERT INTO Patients (FullName, Gender) VALUES (@name, @gender)";
                    using (SQLiteCommand cmdPatient = new SQLiteCommand(insertPatientQuery, conn))
                    {
                        cmdPatient.Parameters.AddWithValue("@name", txtFullName.Text);
                        cmdPatient.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                        cmdPatient.ExecuteNonQuery();
                    }


                    string getIDQuery = "SELECT last_insert_rowid()";
                    long newPatientID;
                    using (SQLiteCommand cmdGetID = new SQLiteCommand(getIDQuery, conn))
                    {
                        newPatientID = (long)cmdGetID.ExecuteScalar();
                    }

                 
                    string insertVisitQuery = "INSERT INTO Visits (PatientID, Priority, Status) VALUES (@patID, @priority, 'Pending_Nurse')";
                    using (SQLiteCommand cmdVisit = new SQLiteCommand(insertVisitQuery, conn))
                    {
                        cmdVisit.Parameters.AddWithValue("@patID", newPatientID);
                        cmdVisit.Parameters.AddWithValue("@priority", cmbPriority.SelectedItem.ToString());
                        cmdVisit.ExecuteNonQuery();
                    }

                    
                    MessageBox.Show(txtFullName.Text + " has been successfully added to the queue!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtFullName.Clear();
                    cmbGender.SelectedIndex = -1;
                    cmbPriority.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GuardDashBoardUC_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
       
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
              
                LoginUC loginScreen = new LoginUC();
                loginScreen.Dock = DockStyle.Fill;

              
                this.Parent.Controls.Add(loginScreen);

             
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
