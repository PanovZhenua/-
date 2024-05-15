using System.Linq;
using System.Windows;

namespace Индивидуальный_Проект
{
    public partial class Изменение_Password : Window
    {
        private int userId;

        public Изменение_Password(int userID)
        {
            InitializeComponent();
            userId = userID;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (MDZEntities db = new MDZEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);

                if (user != null)
                {
                    if (user.Password == txtCurrentPassword.Text)
                    {
                        // Проверка длины нового пароля
                        if (txtNewPassword.Text.Length >= 3)
                        {
                            user.Password = txtNewPassword.Text;
                            db.SaveChanges();

                            MessageBox.Show("Пароль успешно обновлен.");
                        }
                        else
                        {
                            MessageBox.Show("Пароль должен содержать не менее 3 символов.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный текущий пароль.");
                    }
                }
                else
                {
                    MessageBox.Show("Пользователь не найден.");
                }
            }
        }
    }
}
