using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steem_Office
{
    public partial class frmMain : Form
    {
        private frmLogin login;
        private string username = "";
        private string postingwif = "";
        private bool loggedIn = false;

        public frmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Cef.Initialize(new CefSettings() { CachePath = "Cache" });
            login = new frmLogin();
            login.DataAvailable += new EventHandler(login_DataAvailable);
            login.MdiParent = this;
            login.Show();
        }

        private void login_DataAvailable(object sender, EventArgs e)
        {
            frmLogin child = sender as frmLogin;
            if (child != null)
            {
                string signal = child.Data;
                string[] creds = signal.Split('~');
                username = creds[0];
                postingwif = creds[1];
                login.Hide();
                if (loggedIn == false)
                {
                    frmEditor editor = new frmEditor(signal);
                    editor.MdiParent = this;
                    editor.Show();
                    loggedIn = true;
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void changeLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            login.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditor editor = new frmEditor(username + "~" + postingwif);
            editor.MdiParent = this;
            editor.Show();
        }
    }
}
