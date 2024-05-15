using System;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace Индивидуальный_Проект
{
    public partial class Проверка_на_админа : Window
    {
        public int _userId;
        public int _attemptCount = 0; // Счетчик попыток
        private bool _isAdminWindowOpened = false; // Флаг для отслеживания открытия окна Панель_админа
        private Главное_пользовательское_окно _mainWindow;

        public Проверка_на_админа(int userId, Главное_пользовательское_окно mainWindow)
        {
            InitializeComponent();
            _userId = userId;
            this.Closed += Проверка_на_админа_Closed; // Подписка на событие закрытия окна
            _mainWindow = mainWindow;
        }

        public void Проверка_на_админа_Closed(object sender, EventArgs e)
        {
            if (!_isAdminWindowOpened)
            {
                _mainWindow.Show();
            }
        }

        public void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            string adminCode = PasswordBox.Password;

            if (adminCode == AdminCode)
            {
                // Скрыть главное окно вместо закрытия
                _mainWindow.Hide();

                Панель_админа windowAdmin = new Панель_админа(_userId, _mainWindow);
                windowAdmin.Show();
                _isAdminWindowOpened = true; // Устанавливаем флаг, что окно Панель_админа открыто
                this.Close(); // Закрываем текущее окно после открытия Панель_админа
            }
            else
            {
                _attemptCount++;
                MessageBox.Show($"Неверный код. Осталось попыток: {3 - _attemptCount}");

                if (_attemptCount >= 3)
                {
                    this.Close(); // Закрываем текущее окно
                    HandleFailedAttempts();
                }
            }
        }


        public const string AdminCode = "8520";

        public void HandleFailedAttempts()
        {
            // Убедитесь, что этот код вызывается в потоке пользовательского интерфейса
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => HandleFailedAttempts());
                return;
            }

            // Создайте новый экземпляр MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закройте остальные открытые окна приложения, кроме MainWindow
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window != mainWindow)
                    window.Close();
            }
        }
    }
}
