using System;
using System.Windows;

namespace Индивидуальный_Проект
{
    public partial class Зарепортить_баг : Window
    {
        private int userId;
        private Личный_кабинет KabWindow;

        public Зарепортить_баг(int userId , Личный_кабинет kabWindow)
        {
            InitializeComponent();
            this.userId = userId;
            KabWindow = kabWindow;

        }

        private void OtpravitButton_Click(object sender, RoutedEventArgs e)
        {
            string tema = TemaTextBox.Text.Trim();
            string opisanie = OpisanieTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(tema) || tema.Length < 5)
            {
                MessageBox.Show("Пожалуйста, введите тему (не менее 5 символов)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(opisanie) || opisanie.Length < 5)
            {
                MessageBox.Show("Пожалуйста, введите описание (не менее 5 символов)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime time = DateTime.Now;

            using (MDZEntities db = new MDZEntities())
            {
                BugReport bugReport = new BugReport
                {
                    UserID = userId,
                    Tema = tema,
                    Opisanie = opisanie,
                    Time = time,
                    IsFixed = false
                };

                db.BugReport.Add(bugReport);
                db.SaveChanges();
            }

            MessageBox.Show("Сообщение об ошибке успешно отправлено.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            KabWindow.Show();
        }
    }
}
