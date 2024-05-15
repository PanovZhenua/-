using Индивидуальный_Проект;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Data.Entity;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using System.IO;
using MessageBox = System.Windows.MessageBox;

namespace Индивидуальный_Проект
{
    public partial class Права_админ : Page
    {
        private int userId;
        Users model = new Users();
        public Права_админ(int userId)
        {
            InitializeComponent();
            Clear();
            LoadData();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        void Clear()
        {
            FirstBox.Text = SecondBox.Text = string.Empty;
            saveButton.Content = "Сохранить";
            IzmenittIzobrazhenie.Content = "Добавить";
            deleteButton.IsEnabled = false;
            Podskazka1.Visibility = Visibility.Visible;
            Podskazka2.Visibility = Visibility.Visible;
            Podskazka3.Visibility = Visibility.Collapsed;
            imgDisplay.Visibility = Visibility.Collapsed;
            Proverka();
            model.UserID = 0;

        }
        void LoadData()
        {
            dgv.AutoGenerateColumns = false;
            using (MDZEntities db = new MDZEntities())
            {
                dgv.ItemsSource = db.Users.ToList();
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            imgDisplay.Visibility = Visibility.Visible;
            model.UserName = FirstBox.Text.Trim();
            model.Password = SecondBox.Text.Trim();
            if (imgDisplay.Source != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgDisplay.Source));
                    encoder.Save(ms);
                    ms.Flush();
                    model.Avatarka = ms.ToArray();
                }
            }
            else model.Avatarka = null; // Установить null, если изображение не выбрано

            using (MDZEntities db = new MDZEntities())
            {
                if (saveButton.Content.ToString() == "Сохранить") db.Users.Add(model);
                else if (saveButton.Content.ToString() == "Обновить")
                {
                    // Получение сущности из контекста по идентификатору
                    var entity = db.Users.Find(model.UserID);
                    if (entity != null)
                    {
                        // Обновление полей сущности
                        db.Entry(entity).CurrentValues.SetValues(model);
                    }
                }
                db.SaveChanges();
            }
            Clear();
            LoadData();
            MessageBox.Show("Успешно сохранено");
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                using (MDZEntities db = new MDZEntities())
                {
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Users.Attach(model);
                        db.Users.Remove(model);
                        db.SaveChanges();
                        LoadData();
                        Clear();
                        MessageBox.Show("Успешно удалено");
                    }
                }
            }
        }

        private void dgv_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Получить выбранную строку
            DataGridRow selectedRow = (dgv.ItemContainerGenerator.ContainerFromItem(dgv.SelectedItem) as DataGridRow);

            // Проверить, если строка выбрана
            if (selectedRow != null)
            {
                // Получить выбранный объект данных
                object selectedItem = selectedRow.Item;

                if (selectedItem != null && selectedItem.GetType().GetProperty("UserID") != null)
                {
                    int UserId = Convert.ToInt32(selectedItem.GetType().GetProperty("UserID").GetValue(selectedItem, null));

                    using (MDZEntities db = new MDZEntities())
                    {
                        var user = db.Users.FirstOrDefault(t => t.UserID == UserId);

                        if (user != null)
                        {
                            if (imgDisplay != null)
                            {
                                Podskazka1.Visibility = Visibility.Collapsed;
                                Podskazka2.Visibility = Visibility.Collapsed;
                                imgDisplay.Visibility = Visibility.Visible;
                            }
                            else Podskazka3.Visibility = Visibility.Visible;
                            model = user;
                            Proverka();
                            FirstBox.Text = model.UserName;
                            SecondBox.Text = model.Password;
                            saveButton.Content = "Обновить";
                            IzmenittIzobrazhenie.Content = "Изменить";
                            deleteButton.IsEnabled = true;

                            if (user.Avatarka != null) // Проверка на null
                            {
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = new MemoryStream(user.Avatarka);
                                bitmap.EndInit();
                                imgDisplay.Source = bitmap;
                            }
                            else
                            {
                                // Установить изображение по умолчанию или оставить пустым
                                imgDisplay.Source = null;
                            }
                        }

                    }
                }
            }
        }

        private void IzmenittIzobrazhenie_Click(object sender, RoutedEventArgs e)
        {
            Podskazka1.Visibility = Visibility.Collapsed;
            Podskazka2.Visibility = Visibility.Collapsed;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new System.Uri(openFileDialog.FileName);
                bitmap.EndInit();
                imgDisplay.Source = bitmap;
            }
        }

        private void Prava_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button clickedButton = (System.Windows.Controls.Button)sender;

            switch (clickedButton.Content.ToString())
            {
                case "User":
                    model.TypeUser = 1;
                    break;
                case "Content":
                    model.TypeUser = 2;
                    break;
                case "Admin":
                    model.TypeUser = 3;
                    break;
            }
        }

        private void Proverka()
        {
            switch (model.TypeUser)
            {
                case 1:
                    btnUser.IsEnabled = false;
                    btnContent.IsEnabled = true;
                    btnAdmin.IsEnabled = true;
                    break;
                case 2:
                    btnUser.IsEnabled = true;
                    btnContent.IsEnabled = false;
                    btnAdmin.IsEnabled = true;
                    break;
                case 3:
                    btnUser.IsEnabled = true;
                    btnContent.IsEnabled = true;
                    btnAdmin.IsEnabled = false;
                    break;
            }
        }

    }
}
