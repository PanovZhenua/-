using Индивидуальный_Проект;
using System.Windows;
using System.Linq;

namespace Индивидуальный_Проект
{
    public partial class Регистрация : Window
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Проверка минимальной длины
            if (username.Length < 3 || password.Length < 3)
            {
                MessageBox.Show("Имя пользователя и пароль должны содержать не менее 3 символов.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (MDZEntities db = new MDZEntities())
            {
                // Проверка наличия имени пользователя в таблице Users
                if (db.Users.Any(u => u.UserName == username))
                {
                    MessageBox.Show("Это имя пользователя уже существует.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                Users newUser = new Users
                {
                    UserName = username,
                    Password = password,
                    TypeUser = 1 // Установка типа пользователя на 1
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }

            MessageBox.Show("Регистрация успешна!");
            this.Close();
        }
    }
}