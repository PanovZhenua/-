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
    public partial class БД_Админ : Page
    {
        private int userId;
        Tovari model = new Tovari();
        public БД_Админ(int userId)
        {
            InitializeComponent();
            Clear();
            LoadData();
            ProverkaCveta();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            Clear();
        }
        void Clear()
        {
            FirstBox.Text = SecondBox.Text = ThirdBox.Text = string.Empty;
            saveButton.Content = "Сохранить";
            IzmenittIzobrazhenie.Content = "Добавить";
            deleteButton.IsEnabled = false;
            Podskazka1.Visibility = Visibility.Visible;
            Podskazka2.Visibility = Visibility.Visible;
            Podskazka3.Visibility = Visibility.Collapsed;
            imgDisplay.Visibility = Visibility.Collapsed;
            DorabotkaKnopka.IsEnabled = false;
            OdobrenieKnopka.IsEnabled = false;
            model.TovarID = 0;

        }
        void LoadData()
        {
            dgv.AutoGenerateColumns = false;
            using (MDZEntities db = new MDZEntities())
            {
                dgv.ItemsSource = db.Tovari.ToList();
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            imgDisplay.Visibility = Visibility.Visible;
            model.NazvanieTovara = FirstBox.Text.Trim();
            model.Opisanie = SecondBox.Text.Trim();
            model.Stoimostt = int.Parse(ThirdBox.Text.Trim());
            using (MemoryStream ms = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgDisplay.Source));
                encoder.Save(ms);
                model.Izobrazhenie = ms.ToArray();
            }
            using (MDZEntities db = new MDZEntities())
            {
                if (saveButton.Content.ToString() == "Сохранить") db.Tovari.Add(model);
                else if (saveButton.Content.ToString() == "Обновить")
                {
                    // Получение сущности из контекста по идентификатору
                    var entity = db.Tovari.Find(model.TovarID);
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
                        db.Tovari.Attach(model);
                        db.Tovari.Remove(model);
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
                ProverkaCveta();
                // Получить выбранный объект данных
                object selectedItem = selectedRow.Item;

                // Проверить, если объект данных является типом, содержащим свойство TovarID
                if (selectedItem != null && selectedItem.GetType().GetProperty("TovarID") != null)
                {
                    // Получить значение TovarID из выбранного объекта данных
                    int tovarID = Convert.ToInt32(selectedItem.GetType().GetProperty("TovarID").GetValue(selectedItem, null));

                    using (MDZEntities db = new MDZEntities())
                    {
                        var tovar = db.Tovari.FirstOrDefault(t => t.TovarID == tovarID);

                        if (tovar != null)
                        {
                            if (imgDisplay != null)
                            {
                                Podskazka1.Visibility = Visibility.Collapsed;
                                Podskazka2.Visibility = Visibility.Collapsed;
                                imgDisplay.Visibility = Visibility.Visible;
                            }
                            else Podskazka3.Visibility = Visibility.Visible;
                            model = tovar;
                            FirstBox.Text = model.NazvanieTovara;
                            SecondBox.Text = model.Opisanie;
                            ThirdBox.Text = model.Stoimostt.ToString();
                            saveButton.Content = "Обновить";
                            IzmenittIzobrazhenie.Content = "Изменить";
                            deleteButton.IsEnabled = true;
                            BitmapImage bitmap = new BitmapImage();
                            bitmap.BeginInit();
                            bitmap.StreamSource = new MemoryStream(tovar.Izobrazhenie);
                            bitmap.EndInit();
                            imgDisplay.Source = bitmap;
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

        private void Odobrenie_Click(object sender, RoutedEventArgs e)
        {
            model.ShowType = 1;
            ProverkaCveta();
        }

        private void Dorabotka_Click(object sender, RoutedEventArgs e)
        {
            model.ShowType = 2;
            ProverkaCveta();
        }

        private void ProverkaCveta()
        {
            if (model.ShowType == 1)
            {
                OdobrenieKnopka.IsEnabled = false;
                DorabotkaKnopka.IsEnabled = true;
            }
            else if (model.ShowType == 0)
            {
                OdobrenieKnopka.IsEnabled = true;
                DorabotkaKnopka.IsEnabled = false;
            }
            else
            {
                OdobrenieKnopka.IsEnabled = true;
                DorabotkaKnopka.IsEnabled = true;
            }
        }

    }
}
