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
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Индивидуальный_Проект
{
    public partial class Добавление_товара_с_проверкой : Window
    {
        private int userId;
        Tovari model = new Tovari();
        private ObservableCollection<Tovari> _createdTovari;

        public Добавление_товара_с_проверкой(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            Clear();
            LoadData();
            _createdTovari = new ObservableCollection<Tovari>(GetCreatedTovari());
            DataGridCreatedTovari.ItemsSource = _createdTovari;
        }

        private IEnumerable<Tovari> GetCreatedTovari()
        {
            using (MDZEntities db = new MDZEntities())
            {
                return db.Tovari.Where(t => t.Creator == userId && t.ShowType == 0).ToList();
            }
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
            model.TovarID = 0;

        }
        void LoadData()
        {
            DataGridExistingTovari.AutoGenerateColumns = false;
            using (MDZEntities db = new MDZEntities())
            {
                DataGridExistingTovari.ItemsSource = db.Tovari.ToList();
            }
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            imgDisplay.Visibility = Visibility.Visible;
            model.NazvanieTovara = FirstBox.Text.Trim();
            model.Opisanie = SecondBox.Text.Trim();
            model.Stoimostt = int.Parse(ThirdBox.Text.Trim());
            model.Creator = userId; // Установка идентификатора создателя товара
            model.ShowType = 0; // Установка ShowType в 0 для нового товара

            using (MemoryStream ms = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create((BitmapSource)imgDisplay.Source));
                encoder.Save(ms);
                model.Izobrazhenie = ms.ToArray();
            }

            using (MDZEntities db = new MDZEntities())
            {
                if (saveButton.Content.ToString() == "Сохранить")
                {
                    db.Tovari.Add(model);
                    _createdTovari.Add(model); // Добавление нового товара в коллекцию CreatedTovari
                }
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

    }
}
