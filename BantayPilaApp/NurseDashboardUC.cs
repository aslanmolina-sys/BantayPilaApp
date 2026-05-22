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
    public partial class NurseDashboardUC : UserControl
    {
        public NurseDashboardUC()
        {
            InitializeComponent();
        }

        private void dgvQueue_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void NurseDashboardUC_Load(object sender, EventArgs e)
        {
            string connString = "Data Source=bantaypila.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();


                    string query = @"SELECT v.VisitID, p.FullName, p.Gender, v.Priority 
                         FROM Visits v 
                         JOIN Patients p ON v.PatientID = p.PatientID 
                         WHERE v.Status = 'Pending_Nurse'";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvQueue.DataSource = dt; 
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSendToDoctor_Click(object sender, EventArgs e)
        {

            if (dgvQueue.CurrentRow == null)
            {
                MessageBox.Show("Please click on a patient in the list first!", "Select Patient", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // 
            }

            if (string.IsNullOrWhiteSpace(txtSymptoms.Text))
            {
                MessageBox.Show("Please enter the patient's symptoms before sending them to the doctor.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

 
            int visitID = Convert.ToInt32(dgvQueue.CurrentRow.Cells["VisitID"].Value);

            string connString = "Data Source=bantaypila.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();


                    string updateQuery = "UPDATE Visits SET Symptoms = @symptoms, Status = 'Pending_Doctor' WHERE VisitID = @visitID";

                    using (SQLiteCommand cmd = new SQLiteCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@symptoms", txtSymptoms.Text);
                        cmd.Parameters.AddWithValue("@visitID", visitID);
                        cmd.ExecuteNonQuery();
                    }

 
                    MessageBox.Show("Patient sent to the Doctor successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    txtSymptoms.Clear();


                    string refreshQuery = @"SELECT v.VisitID, p.FullName, p.Gender, v.Priority 
                                FROM Visits v 
                                JOIN Patients p ON v.PatientID = p.PatientID 
                                WHERE v.Status = 'Pending_Nurse'";

                    using (SQLiteCommand cmdRefresh = new SQLiteCommand(refreshQuery, conn))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdRefresh))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvQueue.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSymptoms_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // 1. Ask the user if they are sure they want to log out
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // 2. Create a fresh Login screen
                LoginUC loginScreen = new LoginUC();
                loginScreen.Dock = DockStyle.Fill;

                // 3. Inject the Login screen back into the main window
                this.Parent.Controls.Add(loginScreen);

                // 4. Destroy the current Guard dashboard
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
