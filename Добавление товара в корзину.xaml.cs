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

namespace Индивидуальный_Проект
{
    public partial class Добавление_товара_в_корзину : Window
    {
        private int количество = 1;
        private int UserID { get; set; }
        private int TovarID { get; set; }
        private Главное_пользовательское_окно _mainWindow;

        public Добавление_товара_в_корзину(int userID, int tovarID, Главное_пользовательское_окно mainWindow)
        {
            InitializeComponent();

            this.UserID = userID;
            this.TovarID = tovarID;

            LoadProductDetails();
            _mainWindow = mainWindow;
        }

        private void LoadProductDetails()
        {
            using (MDZEntities db = new MDZEntities())
            {
                var product = db.Tovari.FirstOrDefault(p => p.TovarID == TovarID);

                if (product != null)
                {
                    ProductName.Text = product.NazvanieTovara;
                    ProductDescription.Text = product.Opisanie;
                    if (product.Izobrazhenie != null)
                    {
                        var image = new BitmapImage();
                        using (var mem = new MemoryStream(product.Izobrazhenie))
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
                        ProductImage.Source = image;
                    }

                    // Проверка наличия товара в корзине и отображение соответствующего сообщения
                    var existingCartItem = db.Korzina.FirstOrDefault(k => k.UserID == UserID && k.TovarID == TovarID);
                    if (existingCartItem != null)
                    {
                        ExistingCartItemMessage.Text = $"Этот товар уже в корзине. Текущее количество: {existingCartItem.Kolichestvo}";
                    }

                }
            }
        }

        private void DecreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            if (количество > 1)
            {
                количество--;
                QuantityTextBlock.Text = количество.ToString();
            }
        }

        private void IncreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            количество++;
            QuantityTextBlock.Text = количество.ToString();
        }

        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            using (MDZEntities db = new MDZEntities())
            {
                var product = db.Tovari.FirstOrDefault(p => p.TovarID == TovarID);
                if (product != null)
                {
                    // Проверка, существует ли уже этот товар в корзине для данного пользователя
                    var existingCartItem = db.Korzina.FirstOrDefault(k => k.UserID == UserID && k.TovarID == TovarID);

                    if (existingCartItem != null)
                    {
                        // Увеличение количества существующего товара в корзине
                        existingCartItem.Kolichestvo += количество;
                        existingCartItem.ObshchayaStoimostt = existingCartItem.Kolichestvo.Value * product.Stoimostt.Value;
                    }

                    else
                    {
                        // Добавление нового товара в корзину
                        Korzina model = new Korzina();
                        model.UserID = UserID;
                        model.TovarID = TovarID;
                        model.Kolichestvo = количество;
                        model.ObshchayaStoimostt = product.Stoimostt * количество; // Расчет общей стоимости
                        db.Korzina.Add(model);
                    }

                    db.SaveChanges();
                }
            }

            MessageBox.Show("Товар добавлен в корзину!");
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _mainWindow?.Show();
        }
    }
}