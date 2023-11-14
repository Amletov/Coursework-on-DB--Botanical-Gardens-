using DataBaseKursRabota.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseKursRabota.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Проверка логина и пароля
            string enteredUsername = txtUsername.Text;
            string enteredPassword = txtPassword.Text;

            if (IsValidLogin(enteredUsername, enteredPassword))
            {
                // Если логин и пароль верны, показываем сообщение и открываем главную форму
                MessageBox.Show("Вход выполнен успешно!");
                IMainView view = new MainView();
                new MainPresenter(view);
                this.Hide();
            }
            else
            {
                // Если логин и пароль неверны, выводим сообщение об ошибке
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, повторите попытку.");
            }
        }

        private bool IsValidLogin(string username, string password)
        {
            return username == "postgres" && password == "0988";
        }

    }
}
