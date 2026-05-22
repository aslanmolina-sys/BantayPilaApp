using DevExpress.XtraEditors;
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
    public partial class LoginUC : DevExpress.XtraEditors.XtraUserControl
    {
        public LoginUC()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connString = "Data Source=bantaypila.db;Version=3;";

            using (SQLiteConnection conn = new SQLiteConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Role FROM Users WHERE Username = @user AND Password = @pass";

                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                        cmd.Parameters.AddWithValue("@pass", txtpassword.Text);

                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string userRole = reader["Role"].ToString();

                                MessageBox.Show("Access Granted! You are logged in as: " + userRole,
                                                "Login Successful",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Username or Password.",
                                                "Access Denied",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Connection Error: " + ex.Message,
                                    "Critical Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }

        }
    }
}
