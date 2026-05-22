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
    }
}
