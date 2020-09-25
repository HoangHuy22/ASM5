using JsonUWP.Adapters;
using JsonUWP.Model;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JsonUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductDetail : Page
    {
        public ProductDetail()
        {
            this.InitializeComponent();
        }


        private Product Detail
        {
            get;
            set;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Detail = e.Parameter as Product;
        }

        private void BtnLike_Click(object sender, RoutedEventArgs e)
        {
            SQLiteHelper sQLiteHelper = SQLiteHelper.createInstance();

            SQLiteConnection sQLiteConnection = sQLiteHelper.sQLiteConnection;
            var sqlString = "INSERT INTO Products(id,name,image,description,price) VALUES(?,?,?,?,?)";
            var stt = sQLiteConnection.Prepare(sqlString);
            stt.Bind(1, Detail.id);
            stt.Bind(2, Detail.name);
            stt.Bind(3, Detail.image);
            stt.Bind(4, Detail.description);
            stt.Bind(5, Detail.price);
            stt.Step();
            MainPage.mainFrame.Navigate(typeof(Favourite));
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            CartItem item = new CartItem(Detail.id, Detail.name, Detail.image, Detail.price, Convert.ToInt32(Qty.Text));
            Cart cart = new Cart();
            cart.AddToCart(item);
            MainPage.mainFrame.Navigate(typeof(Home));
        }
    }
}
