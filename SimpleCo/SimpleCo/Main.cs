using Bunifu.Framework.UI;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gecko;
using Gecko.Services;
using Gecko.Events;

namespace SimpleCo
{
    public partial class Main : DevExpress.XtraBars.TabForm
    {                                   

        public Main()
        {
            InitializeComponent();
            this.tabPageContent.Controls.Add(tab);                           
                                                        
        }


        public void OnOuterFormCreating(object sender, OuterFormCreatingEventArgs e)
        {
            Main form = new Main();
            form.TabFormControl.Pages.Clear();
            e.Form = form;
            OpenFormCount++;
        }
        static int OpenFormCount = 1;
           
                   
        public void tabbedForm_PageCreated(object sender, PageCreatedEventArgs e)
        {    
            xtraUsrCntrlTab newtab = new xtraUsrCntrlTab();
            newtab.Dock = DockStyle.Fill;
            e.Page.ContentContainer.Controls.Add(newtab);

        }
        public void tabbedForm_PageClosed(object sender, PageClosedEventArgs e)
        {
            if (tabbedForm.TabIndex <= 1)
            {
                this.Close();
            }
        }

        public void Main_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {                         
         tabPageContent.Dispose();        
            tabPage.Dispose();
                    tabbedForm.Dispose();
            tab.Dispose();

            base.Dispose();

            OpenFormCount--;
                    
        }
        public void Main_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Close();
            this.Dispose();

        }
    }
              
}
