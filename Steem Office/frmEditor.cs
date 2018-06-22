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
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace Steem_Office
{
    public partial class frmEditor : Form
    {
        public ChromiumWebBrowser browser;
        private string[] creds;

        public frmEditor(string input)
        {
            InitializeComponent();
            creds = input.Split('~');
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            string user = creds[0];
            string key = creds[1];
            browser = new ChromiumWebBrowser("file:///steemwriter.html?" + user + "?" + key);
            this.Controls.Add(browser);
            browser.Visible = true;
            browser.Dock = DockStyle.Fill;
        }
    }
}
