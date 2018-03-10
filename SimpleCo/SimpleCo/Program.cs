using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using System.Reflection;
using System.ComponentModel;
using DevExpress.XtraEditors;
using Gecko;

namespace SimpleCo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Assembly asm = typeof(DevExpress.UserSkins.liked).Assembly;
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            UserLookAndFeel.Default.SkinName = "Default";
            Xpcom.Initialize("Firefox");
            new Main().Show();
            Application.Run();
        }
    }
}
