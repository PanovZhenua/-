using System.Linq;
using System.Windows;

namespace Индивидуальный_Проект
{
    public partial class Изменение_UserName : Window
    {
        private int userId;

        public Изменение_UserName(int userID)
        {
            InitializeComponent();
            userId = userID;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            using (MDZEntities db = new MDZEntities())
            {
                // Поиск пользователя по UserID
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);

                if (user != null)
                {
                    // Проверка пароля
                    if (user.Password == txtPassword.Text)
                    {
                        // Проверка длины нового UserName
                        if (txtNewUserName.Text.Length >= 3)
                        {
                            // Проверка уникальности нового UserName
                            if (!db.Users.Any(u => u.UserName == txtNewUserName.Text && u.UserID != userId))
                            {
                                // Обновление UserName
                                user.UserName = txtNewUserName.Text;
                                db.SaveChanges();

                                MessageBox.Show("UserName успешно обновлен.");
                            }
                            else
                            {
                                MessageBox.Show("Пользователь с таким UserName уже существует.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("UserName должен содержать не менее 3 символов.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль.");
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
