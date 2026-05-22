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
using System.Data;

namespace BantayPilaApp
{
    public partial class DoctorDashboardUC : UserControl
    {
        public DoctorDashboardUC()
        {
            InitializeComponent();
        }

        private void DoctorDashboardUC_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=bantaypila.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();


                    string query = @"SELECT v.VisitID, p.FullName, v.Priority, v.Symptoms 
                         FROM Visits v 
                         JOIN Patients p ON v.PatientID = p.PatientID 
                         WHERE v.Status = 'Pending_Doctor'";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDoctorQueue.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            // 1. Make sure the doctor actually clicked a patient
            if (dgvDoctorQueue.CurrentRow == null)
            {
                MessageBox.Show("Please select a patient from the list first!", "Select Patient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop the code
            }

            // 2. Make sure the doctor wrote a diagnosis or prescription
            if (string.IsNullOrWhiteSpace(txtDoctorNotes.Text))
            {
                MessageBox.Show("Please enter your diagnosis and prescription notes.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Stop the code
            }

            // 3. Grab the specific VisitID of the patient they clicked
            int visitID = Convert.ToInt32(dgvDoctorQueue.CurrentRow.Cells["VisitID"].Value);

            string connString = "Data Source=bantaypila.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();

                    // 4. Update the database: Save the doctor's notes and change status to 'Completed'
                    string updateQuery = "UPDATE Visits SET DoctorNotes = @notes, Status = 'Completed' WHERE VisitID = @visitID";

                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@notes", txtDoctorNotes.Text);
                        cmd.Parameters.AddWithValue("@visitID", visitID);
                        cmd.ExecuteNonQuery(); // Execute the update
                    }

                    // Success message!
                    MessageBox.Show("Visit completed! The patient has been officially discharged.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. Clean up the screen
                    txtDoctorNotes.Clear();

                    // 6. Refresh the Grid (This makes the patient disappear, as they are no longer pending!)
                    string refreshQuery = @"SELECT v.VisitID, p.FullName, v.Priority, v.Symptoms 
                                FROM Visits v 
                                JOIN Patients p ON v.PatientID = p.PatientID 
                                WHERE v.Status = 'Pending_Doctor'";

                    using (SQLiteCommand cmdRefresh = new SQLiteCommand(refreshQuery, conn))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdRefresh))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvDoctorQueue.DataSource = dt; // Load the fresh data
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
