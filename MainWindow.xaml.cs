using System;
using System.Linq;
using System.Windows;

namespace Индивидуальный_Проект
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (MDZEntities db = new MDZEntities())
            {
                string username = txtUsername.Text;
                string password = txtPassword.Password;

                var user = db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

                if (user != null)
                {
                    var window = new Главное_пользовательское_окно(user.UserID); // Передаем UserID
                    window.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверное имя пользователя или пароль.");
                }
            }
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Регистрация RegWindow = new Регистрация();
            RegWindow.Closed += Window_Closed; // Добавляем обработчик события Closed
            RegWindow.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Show(); // Показываем Главное_пользовательское_окно при закрытии Личный_кабинет
        }

    }
}
