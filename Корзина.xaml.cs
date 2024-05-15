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
using System.Collections.Generic;

namespace Индивидуальный_Проект
{
    public partial class Корзина : Window
    {
        private ObservableCollection<KorzinaItem> _cartItems;
        private Главное_пользовательское_окно _mainWindow;

        public Корзина(int userId  , Главное_пользовательское_окно mainWindow)
        {
            InitializeComponent();

            using (MDZEntities db = new MDZEntities())
            {
                var cartItems = db.Korzina
                    .Where(k => k.UserID == userId)
                    .Join(db.Tovari,
                          k => k.TovarID,
                          t => t.TovarID,
                          (k, t) => new KorzinaItem
                          {
                              UserID = userId,
                              TovarID = k.TovarID.Value,
                              NazvanieTovara = t.NazvanieTovara,
                              Stoimostt = t.Stoimostt.Value,
                              Izobrazhenie = t.Izobrazhenie,
                              Kolichestvo = k.Kolichestvo.Value,
                              ObshchayaStoimostt = k.ObshchayaStoimostt.Value,
                              ShowType = t.ShowType.Value
                          })
                    .ToList();

                _cartItems = new ObservableCollection<KorzinaItem>(cartItems);
                CartItemsControl.ItemsSource = _cartItems;
            }
            _mainWindow = mainWindow;
        }

        public class KorzinaItem
        {
            public int UserID { get; set; }
            public int TovarID { get; set; }
            public string NazvanieTovara { get; set; }
            public decimal Stoimostt { get; set; }
            public byte[] Izobrazhenie { get; set; }
            public int Kolichestvo { get; set; }
            public decimal ObshchayaStoimostt { get; set; }
            public int ShowType { get; set; }
        }

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is KorzinaItem item)
                {
                    using (MDZEntities db = new MDZEntities())
                    {
                        var cartItem = db.Korzina.FirstOrDefault(k => k.UserID == item.UserID && k.TovarID == item.TovarID);
                        if (cartItem != null && cartItem.Kolichestvo > 1)
                        {
                            cartItem.Kolichestvo--;
                            cartItem.ObshchayaStoimostt = cartItem.Kolichestvo.Value * db.Tovari.FirstOrDefault(t => t.TovarID == cartItem.TovarID).Stoimostt.Value;
                            db.SaveChanges();
                        }
                    }
                    RefreshCartItems(item.UserID);
                }
            }
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.DataContext is KorzinaItem item)
                {
                    using (MDZEntities db = new MDZEntities())
                    {
                        var cartItem = db.Korzina.FirstOrDefault(k => k.UserID == item.UserID && k.TovarID == item.TovarID);
                        if (cartItem != null)
                        {
                            cartItem.Kolichestvo++;
                            cartItem.ObshchayaStoimostt = cartItem.Kolichestvo.Value * db.Tovari.FirstOrDefault(t => t.TovarID == cartItem.TovarID).Stoimostt.Value;
                            db.SaveChanges();
                        }
                    }
                    RefreshCartItems(item.UserID);
                }
            }
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {

                if (button.DataContext is KorzinaItem item)
                {
                    using (MDZEntities db = new MDZEntities())
                    {
                        var cartItem = db.Korzina.FirstOrDefault(k => k.UserID == item.UserID && k.TovarID == item.TovarID);
                        if (cartItem != null)
                        {
                            db.Korzina.Remove(cartItem);
                            db.SaveChanges();
                        }
                    }
                    RefreshCartItems(item.UserID);
                }
            }
        }

        private void RefreshCartItems(int userId)
        {
            using (MDZEntities db = new MDZEntities())
            {
                var cartItems = db.Korzina
                    .Where(k => k.UserID == userId)
                    .Join(db.Tovari,
                          k => k.TovarID,
                          t => t.TovarID,
                          (k, t) => new KorzinaItem
                          {
                              UserID = userId,
                              TovarID = k.TovarID.Value,
                              NazvanieTovara = t.NazvanieTovara,
                              Stoimostt = t.Stoimostt.Value,
                              Izobrazhenie = t.Izobrazhenie,
                              Kolichestvo = k.Kolichestvo.Value,
                              ObshchayaStoimostt = k.ObshchayaStoimostt.Value,
                              ShowType = t.ShowType.Value
                          })
                    .ToList();

                _cartItems = new ObservableCollection<KorzinaItem>(cartItems);
                CartItemsControl.ItemsSource = _cartItems;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _mainWindow?.Show();
        }

    }

    public class NullVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ShowTypeVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int showType)
            {
                switch (showType)
                {
                    case 1:
                        return string.Empty;
                    default:
                        return "Товар закончился!";
                }
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class ShowTypeButtonEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int showType = (int)value;

            if (parameter != null)
            {
                if (int.TryParse(parameter.ToString(), out int enabledShowType))
                {
                    return showType == enabledShowType;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}