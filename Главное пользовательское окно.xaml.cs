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
    public partial class Главное_пользовательское_окно : Window
    {
        private ObservableCollection<Tovari> _products;
        private ObservableCollection<Tovari> _filteredProducts;
        private int _userId;

        public Главное_пользовательское_окно(int userId)
        {
            InitializeComponent();
            _userId = userId;
            Activated += Главное_пользовательское_окно_Activated;

            using (MDZEntities db = new MDZEntities())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);

                if (user != null)
                {
                    AddProductButton.Visibility = user.TypeUser == 2 || user.TypeUser == 3 ? Visibility.Visible : Visibility.Collapsed;
                    AdminPanelButton.Visibility = user.TypeUser == 3 ? Visibility.Visible : Visibility.Collapsed;
                }
            }

            LoadProducts();
        }

        private void Главное_пользовательское_окно_Activated(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (MDZEntities db = new MDZEntities())
            {
                var visibleProducts = db.Tovari.Where(t => t.ShowType == 1).ToList();

                _products = new ObservableCollection<Tovari>(visibleProducts);
                _filteredProducts = new ObservableCollection<Tovari>(_products);
                productItemsControl.ItemsSource = _filteredProducts;
            }
        }

        private void ProductItem_Click(object sender, RoutedEventArgs e)
        {
            Tovari selectedProduct = null;
            if (e.OriginalSource is FrameworkElement element)
            {
                selectedProduct = element.DataContext as Tovari;
            }

            if (selectedProduct != null)
            {
                Добавление_товара_в_корзину addToCartPage = new Добавление_товара_в_корзину(_userId, selectedProduct.TovarID, this);
                addToCartPage.Show();
                this.Hide();
            }
        }


        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            Добавление_товара_с_проверкой WindowContent = new Добавление_товара_с_проверкой(_userId);
            WindowContent.Closed += Window_Closed;
            WindowContent.Show();
            this.Hide();
        }


        private void AdminPanelButton_Click(object sender, RoutedEventArgs e)
        {
            Проверка_на_админа WindowAdmin = new Проверка_на_админа(_userId, this);
            WindowAdmin.Show();
            this.Hide();
        }


        private void PersonalAccountButton_Click(object sender, RoutedEventArgs e)
        {
            Личный_кабинет personalAccountWindow = new Личный_кабинет(_userId, this);
            personalAccountWindow.Closed += Window_Closed; // Добавляем обработчик события Closed
            personalAccountWindow.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Show(); // Показываем Главное_пользовательское_окно при закрытии Личный_кабинет
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            Корзина cartWindow = new Корзина(_userId, this);
            cartWindow.Show();
            this.Hide();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterProducts();
        }

        private void PriceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FilterProducts();
        }
        private void FilterProducts()
        {
            string searchText = SearchTextBox.Text.ToLower();
            int minPrice = (int)MinPriceSlider.Value;
            int maxPrice = (int)MaxPriceSlider.Value;

            if (_products != null)
            {
                _filteredProducts = new ObservableCollection<Tovari>(
                    _products.Where(p => p.NazvanieTovara.ToLower().Contains(searchText) && p.Stoimostt >= minPrice && p.Stoimostt <= maxPrice));
            }
            else
            {
                _filteredProducts = new ObservableCollection<Tovari>();
            }

            if (productItemsControl != null)
            {
                productItemsControl.ItemsSource = _filteredProducts;
            }
        }

        private void MinPriceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MinPriceTextBox != null)
            {
                MinPriceTextBox.Text = e.NewValue.ToString("N0");
            }
        }

        private void MaxPriceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (MaxPriceTextBox != null)
            {
                MaxPriceTextBox.Text = e.NewValue.ToString("N0");
            }
        }

        private void ApplyFilterButton_Click(object sender, RoutedEventArgs e)
        {
            FilterProducts();
        }

    }
    public class ByteArrayToBitmapImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                byte[] bytes = value as byte[];
                if (bytes != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.StreamSource = ms;
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.EndInit();
                        return image;
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}