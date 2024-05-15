using System;
using System.Windows;
using System.Windows.Controls;

namespace Индивидуальный_Проект
{
    public partial class Панель_админа : Window
    {
        private int userId;
        private Главное_пользовательское_окно _mainWindow;
        public Панель_админа(int userId, Главное_пользовательское_окно mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            this.userId = userId;

            MainFrame.Navigate(new Права_админ(userId));
        }

        private void Navigation_Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;

            switch (clickedButton.Content.ToString())
            {
                case "Права админ":
                    MainFrame.Navigate(new Права_админ(userId));
                    break;
                case "БД Админ":
                    MainFrame.Navigate(new БД_Админ(userId));
                    break;
                case "Баги":
                    MainFrame.Navigate(new Отчёт_об_ошибках(userId));
                    break;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _mainWindow?.Show();
        }

    }
}