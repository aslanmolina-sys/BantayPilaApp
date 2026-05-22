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
            // Check if the guard left the name blank
            if (string.IsNullOrWhiteSpace(txtFullName.Text) || cmbGender.SelectedItem == null || cmbPriority.SelectedItem == null)
            {
                MessageBox.Show("Please fill out Name, Gender, and Priority!", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop the code right here
            }

            string connString = "Data Source=bantaypila.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 1. Save the Patient to the database
                    string insertPatientQuery = "INSERT INTO Patients (FullName, Gender) VALUES (@name, @gender)";
                    using (SQLiteCommand cmdPatient = new SQLiteCommand(insertPatientQuery, conn))
                    {
                        cmdPatient.Parameters.AddWithValue("@name", txtFullName.Text);
                        cmdPatient.Parameters.AddWithValue("@gender", cmbGender.SelectedItem.ToString());
                        cmdPatient.ExecuteNonQuery();
                    }

                    // 2. Get the ID of the patient we just created
                    string getIDQuery = "SELECT last_insert_rowid()";
                    long newPatientID;
                    using (SQLiteCommand cmdGetID = new SQLiteCommand(getIDQuery, conn))
                    {
                        newPatientID = (long)cmdGetID.ExecuteScalar();
                    }

                    // 3. Put that patient into the Queue (Visits table)
                    string insertVisitQuery = "INSERT INTO Visits (PatientID, Priority, Status) VALUES (@patID, @priority, 'Pending_Nurse')";
                    using (SQLiteCommand cmdVisit = new SQLiteCommand(insertVisitQuery, conn))
                    {
                        cmdVisit.Parameters.AddWithValue("@patID", newPatientID);
                        cmdVisit.Parameters.AddWithValue("@priority", cmbPriority.SelectedItem.ToString());
                        cmdVisit.ExecuteNonQuery();
                    }

                    // 4. Success Message & Clear the form for the next person
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
    }
}
