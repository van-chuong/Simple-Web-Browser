using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate("https://www.bing.com/");

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser.Navigate(tbKey.Text.Trim());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            webBrowser.GoBack();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser.GoForward();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(btnRefresh.Image == imgCancel.Image)
            {
                webBrowser.Stop();
            }
            else
            {
                webBrowser.Refresh();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            webBrowser.GoHome();

        }
        void ChangeUrl()
        {
            tbKey.Text = webBrowser.Url.ToString();
        }


        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            btnRefresh.Image = imgCancel.Image;
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            btnRefresh.Image = imgRefresh.Image;
            tbKey.Text = webBrowser.Url.AbsoluteUri;
        }

        private void tbKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbKey.Text.Trim().Length > 0)
            {
                if (tbKey.Text.Trim().Contains("."))
                {
                    webBrowser.Navigate(tbKey.Text.Trim());
                }
                else
                {
                    webBrowser.Navigate("https://www.google.com/search?client=opera&q=" + tbKey.Text.Trim().Replace(" ","+")+ "&sourceid=opera&ie=UTF-8&oe=UTF-8");
                }
            }
        }
    }
}
