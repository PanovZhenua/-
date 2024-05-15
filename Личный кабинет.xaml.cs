using Индивидуальный_Проект;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.IdentityModel.Metadata;
using System.Data.Entity;
using System.Windows.Input;

namespace Индивидуальный_Проект
{
    public partial class Личный_кабинет : Window
    {
        private int userId;
        Users model = new Users();
        private Главное_пользовательское_окно mainWindow;

        public Личный_кабинет(int userId, Главное_пользовательское_окно mainWindow)
        {
            InitializeComponent();
            this.userId = userId;
            LoadUserDetails();
            this.mainWindow = mainWindow;
        }

        private void LoadUserDetails()
        {
            using (MDZEntities db = new MDZEntities())
            {
                var user = db.Users.Find(userId);
                if (user != null)
                {
                    UserNameLabel.Text += user.UserName;

                    if (user.Avatarka != null)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(user.Avatarka))
                        {
                            mem.Position = 0;
                            image.BeginInit();
                            image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                            image.CacheOption = BitmapCacheOption.OnLoad;
                            image.UriSource = null;
                            image.StreamSource = mem;
                            image.EndInit();
                        }
                        image.Freeze();
                        UserAvatar.Source = image;
                        ChangeAvatarButton.Content = "Изменить аватарку";
                    }
                    else
                    {
                        ChangeAvatarButton.Content = "Добавить аватарку";
                    }
                }
            }
        }

        private void ChangeAvatarButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new System.Uri(openFileDialog.FileName);
                bitmap.EndInit();
                UserAvatar.Source = bitmap;

                using (MemoryStream ms = new MemoryStream())
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)UserAvatar.Source));
                    encoder.Save(ms);
                    ms.Position = 0;

                    using (MDZEntities db = new MDZEntities())
                    {
                        var user = db.Users.Find(userId);
                        if (user != null)
                        {
                            // Обновляем поле Avatarka существующей записи
                            user.Avatarka = ms.ToArray();
                            db.Entry(user).State = EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
            }
        }

        private void ChangeUsernameButton_Click(object sender, RoutedEventArgs e)
        {
            Изменение_UserName changeUserNameWindow = new Изменение_UserName(userId);
            changeUserNameWindow.ShowDialog();
        }

        private void ChangePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            Изменение_Password changePasswordWindow = new Изменение_Password(userId);
            changePasswordWindow.ShowDialog();
        }
        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Убедитесь, что этот код вызывается в потоке пользовательского интерфейса
            if (!Dispatcher.CheckAccess())
            {
                Dispatcher.Invoke(() => LogoutButton_Click(sender, e));
                return;
            }

            // Создайте новый экземпляр MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            // Закройте текущее окно после открытия MainWindow
            this.Close();

            // Закройте остальные открытые окна приложения, кроме MainWindow
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window != this && window != mainWindow)
                    window.Close();
            }
        }
        private void ReportBugButton_Click(object sender, MouseButtonEventArgs e)
        {
            Зарепортить_баг reportBugWindow = new Зарепортить_баг(userId, this);
            reportBugWindow.Show();
            this.Hide();
        }

    }
}