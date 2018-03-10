using Gecko;
namespace SimpleCo
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            //base.Dispose(disposing);
            if (--OpenFormCount == 0) System.Windows.Forms.Application.Exit();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {                                            
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabbedForm = new DevExpress.XtraBars.TabFormControl();
            this.tabPage = new DevExpress.XtraBars.TabFormPage();
            this.tabPageContent = new DevExpress.XtraBars.TabFormContentContainer();
            this.skinRegistration1 = new SimpleCo.SkinRegistration();
            this.tab = new xtraUsrCntrlTab();                    
           
            ((System.ComponentModel.ISupportInitialize)(this.tabbedForm)).BeginInit();
            this.tabPageContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabbedForm
            // 
            this.tabbedForm.Location = new System.Drawing.Point(0, 0);
            this.tabbedForm.Name = "tabbedForm";
            this.tabbedForm.Pages.Add(this.tabPage);
            this.tabbedForm.SelectedPage = this.tabPage;
            this.tabbedForm.Size = new System.Drawing.Size(760, 53);
            this.tabbedForm.TabForm = this;
            this.tabbedForm.TabIndex = 0;
            this.tabbedForm.TabStop = false;
            this.tabbedForm.PageClosed += new DevExpress.XtraBars.PageClosedEventHandler(this.tabbedForm_PageClosed);
            this.tabbedForm.PageCreated += new DevExpress.XtraBars.PageCreatedEventHandler(this.tabbedForm_PageCreated);
            this.tabbedForm.OuterFormCreating += new DevExpress.XtraBars.OuterFormCreatingEventHandler(this.OnOuterFormCreating);
            // 
            // tabPage
            // 
            this.tabPage.ContentContainer = this.tabPageContent;
            this.tabPage.Name = "tabPage";
            this.tabPage.Text = "New Tab";
            // 
            // tabPageContent
            //                                           
            this.tabPageContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPageContent.Location = new System.Drawing.Point(0, 53);
            this.tabPageContent.Name = "tabPageContent";
            this.tabPageContent.Size = new System.Drawing.Size(760, 365);
            this.tabPageContent.TabIndex = 1;
            //
            // Tab
            //
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Name = "Tab";             
            //
            // Main
            // 
            this.FormClosed += Main_FormClosed;
            this.FormClosing += Main_FormClosing;  
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 418);
            this.Controls.Add(this.tabPageContent);
            this.Controls.Add(this.tabbedForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Default";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Main";
            this.TabFormControl = this.tabbedForm;
            this.Text = "SimpleCo";
            ((System.ComponentModel.ISupportInitialize)(this.tabbedForm)).EndInit();
            this.tabPageContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion
        private SkinRegistration skinRegistration1;    
        public DevExpress.XtraBars.TabFormControl tabbedForm;
        public DevExpress.XtraBars.TabFormContentContainer tabPageContent;
        public DevExpress.XtraBars.TabFormPage tabPage;
        public xtraUsrCntrlTab tab;     
     
    }
}

