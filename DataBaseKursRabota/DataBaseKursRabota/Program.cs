using DataBaseKursRabota.Models;
using DataBaseKursRabota.Presenters;
using DataBaseKursRabota.Repositories;
using DataBaseKursRabota.Views;

namespace DataBaseKursRabota
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //IMainView view = new MainView();
            //new MainPresenter(view);
            //Application.Run((Form)view);
            Application.Run(new LoginForm());
        }
    }
}