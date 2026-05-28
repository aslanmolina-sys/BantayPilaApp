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
           
            LoginUC loginScreen = new LoginUC();

          
            loginScreen.Dock = DockStyle.Fill;

           
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

