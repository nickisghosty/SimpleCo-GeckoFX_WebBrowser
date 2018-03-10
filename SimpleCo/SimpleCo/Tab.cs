using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using Gecko;
using Bunifu.Framework.UI;
using DevExpress.XtraPrinting.HtmlExport.Native;
using System.IO;
using Gecko.Events;

namespace SimpleCo
{
    public partial class xtraUsrCntrlTab : DevExpress.XtraEditors.XtraUserControl
    {
        #region Global Variables              

        public static string searchUrl = "https://www.google.com/#q=";
        public static string newTabUrl = "about:blank";
        public static string Branding = "SimpleCo";

        public string homeUrl = "http://google.com/";

        #endregion

        public xtraUsrCntrlTab()
        {
            InitializeComponent();                                  


            browser1.Navigate("http://google.com");

        }
           
        #region Buttons Animation
        private void btns_MouseEnter(object sender, EventArgs e)
        {
            BunifuImageButton btn = (BunifuImageButton)sender;
            string btnhov = btn.Name + "hov";
            btn.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(btnhov);
        }
        private void btns_MouseHover(object sender, EventArgs e)
        {
            BunifuImageButton btn = (BunifuImageButton)sender;
            string btnhov = btn.Name + "hov";
            btn.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(btnhov);
        }
        private void btns_MouseLeave(object sender, EventArgs e)
        {
            BunifuImageButton btn = (BunifuImageButton)sender;
            string normbtn = btn.Name;
            btn.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(normbtn);
        }
        private void btns_MouseDown(object sender, MouseEventArgs e)
        {
            BunifuImageButton btn = (BunifuImageButton)sender;
            string btndown = btn.Name + "down";
            btn.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(btndown);
        }
        private void btns_MouseUp(object sender, MouseEventArgs e)
        {
            BunifuImageButton btn = (BunifuImageButton)sender;
            string btnhov = btn.Name + "hov";

            btn.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject(btnhov);
        }
        #endregion

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadURL(txtUrl.Text);
            }
        }

        private void LoadURL(string url)
        {
            Uri outUri;
            string newUrl = url;
            string urlLower = url.Trim().ToLower();

           

            // load page
            if (urlLower == "localhost")
            {

                newUrl = "http://localhost/";

            }
            else if (url.CheckIfFilePath() || url.CheckIfFilePath2())
            {

                newUrl = url.PathToURL();

            }
            else
            {

                Uri.TryCreate(url, UriKind.Absolute, out outUri);

                if (!(urlLower.StartsWith("http") || urlLower.StartsWith("sharpbrowser")))
                {
                    if (outUri == null || outUri.Scheme != Uri.UriSchemeFile) newUrl = "http://" + url;
                }

                if (urlLower.StartsWith("sharpbrowser:") ||

                    // load URL if it seems valid
                    (Uri.TryCreate(newUrl, UriKind.Absolute, out outUri)
                     && ((outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps) && newUrl.Contains(".") || outUri.Scheme == Uri.UriSchemeFile)))
                {

                }
                else
                {

                    // run search if unknown URL
                      newUrl = searchUrl + DXHttpUtility.UrlEncodeToUnicodeCompatible(url);

                }

            }
            // load URL
           browser1.Navigate(newUrl);

            // set URL in UI
            txtUrl.Text = newUrl;         

        }

   public void browser_CreateWindow(object sender, GeckoCreateWindowEventArgs e)
   {
       e.Cancel = true;
            Main main = new Main();
            main.Show();
            main.tab.browser1.Navigate(e.Uri);
           main.tab.browser1.DocumentCompleted += WebBrowser_DocumentCompleted;
            main.tab.browser1.DocumentTitleChanged += Browser1_DocumentTitleChanged;
           

   }

        private void Browser1_DocumentTitleChanged(object sender, EventArgs e)
        {
            Browser browser = (Browser)sender;
            Main main = browser.FindForm() as Main;

            main.tabbedForm.SelectedPage.Text = this.browser1.DocumentTitle;
            main.Text = "SimpleCo - " + this.browser1.DocumentTitle;

            var faviconmem = new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(@"https://www.google.com/s2/favicons?domain_url=" + this.browser1.Url.AbsoluteUri));
            var img = System.Drawing.Bitmap.FromStream(faviconmem);
            main.tabbedForm.SelectedPage.Image = img;
        }

        private void WebBrowser_DocumentCompleted(object sender, GeckoDocumentCompletedEventArgs e)
        {
            if (!browser1.IsBusy)
            {
                txtUrl.Text = browser1.Url.AbsoluteUri;
                progressBar.EditValue = 0;

            }
        }

        public void browser_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }
            

        public void browser_WindowClosed(object sender, EventArgs e)
        {

        }

        public void browser_MouseHover(object sender, EventArgs e)
        {
          txtStatus.Text = browser1.Text;     

        }

        public void browser_DocumentCompleted(object sender, Gecko.Events.GeckoDocumentCompletedEventArgs e)
        {   if (!browser1.IsBusy)
            {
               txtUrl.Text = browser1.Url.AbsoluteUri;
                progressBar.EditValue = 0;

            }    
        }

        public void browser_Navigating(object sender, Gecko.Events.GeckoNavigatingEventArgs e)
        {     
          
           txtUrl.Text = e.Uri.AbsoluteUri;
                                       
        }

        public void browser_ProgressChanged(object sender, Gecko.GeckoProgressEventArgs e)
        {
          
            progressBar.Properties.Maximum = (int)e.MaximumProgress;

            if ((int)e.CurrentProgress <= 0)
            {
                progressBar.EditValue = 0;
            }
            else
            {
                progressBar.EditValue = (int)e.CurrentProgress;
            }  
        }

        public void browser_Redirecting(object sender, Gecko.GeckoRedirectingEventArgs e)
        {

        }

        public void browser_Retargeted(object sender, Gecko.Events.GeckoRetargetedEventArgs e)
        {

        }

        public void browser_CanGoBackChanged(object sender, EventArgs e)
        { 
             if (browser1.CanGoBack)
            {
                btnBack.Enabled = true;
            }
            else
            {
                btnBack.Enabled = false;
            }    
        }

        public void browser_CanGoForwardChanged(object sender, EventArgs e)
        {
            if (browser1.CanGoForward)
            {
                btnForward.Enabled = true;
            }
            else
            {
                btnForward.Enabled = false;
            }   
        }

        public void browser_DocumentTitleChanged(object sender, EventArgs e)
        {
            Main main = (Main)Application.OpenForms["Main"];

            main.tabbedForm.SelectedPage.Text = this.browser1.DocumentTitle;
            main.Text = "SimpleCo - " + this.browser1.DocumentTitle;

            var faviconmem = new System.IO.MemoryStream(new System.Net.WebClient().DownloadData(@"https://www.google.com/s2/favicons?domain_url=" + this.browser1.Url.AbsoluteUri));
            var img = System.Drawing.Bitmap.FromStream(faviconmem);
            main.tabbedForm.SelectedPage.Image = img;  
        }

        public void browser_LocationChanged(object sender, EventArgs e)
        {  
            txtUrl.Text = browser1.Url.AbsoluteUri;
                                                       
        }

        public void browser_StatusTextChanged(object sender, EventArgs e)
        {
           
            txtStatus.Text = browser1.StatusText;
                                     
        }

        public void browser_NavigationError(object sender, Gecko.Events.GeckoNavigationErrorEventArgs e)
        {

        }

        public void browser_Load(object sender, Gecko.DomEventArgs e)
        {
            
            txtUrl.Text = e.Target.ToString();
                                                        
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
           browser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            browser1.GoForward();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
           browser1.Navigate(homeUrl);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            browser1.Reload();
        }

        private void Tab_Load(object sender, EventArgs e)
        {

        }

        private void checkButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void browser1_Click(object sender, EventArgs e)
        {

        }

        private void panelControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
