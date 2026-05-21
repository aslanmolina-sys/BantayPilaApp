using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BantayPilaApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // 1. Create the login screen
            LoginUC loginScreen = new LoginUC();

            // 2. Make it stretch to fill the space
            loginScreen.Dock = DockStyle.Fill;

            // 3. Inject it into the main panel
            panelMain.Controls.Add(loginScreen);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelSidebar_Paint(object sender, PaintEventArgs e)
        {

        }



        }
    }

