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
using SQLitePCL;
using JsonUWP.Adapters;
using JsonUWP.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace JsonUWP.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Favourite : Page
    {
        public Favourite()
        {
            this.InitializeComponent();
            GetFavourite();
        }

        private void GetFavourite()
        {
            SQLiteHelper sQLiteHelper = SQLiteHelper.createInstance();
            SQLiteConnection sQLiteConnection = sQLiteHelper.sQLiteConnection;
            var sqlString = "SELECT * FROM Products";
            var stt = sQLiteConnection.Prepare(sqlString);
            List<Product> arr = new List<Product>();
            while (SQLiteResult.ROW == stt.Step())
            {
                var id = Convert.ToInt32(stt[0]);
                var name = (string)stt[1];
                var image = (string)stt[2];
                var description = (string)stt[3];
                var price = Convert.ToInt32(stt[4]);

                arr.Add(new Product(id, name, image, description, price));
            }
            //Console.WriteLine(arr);
            //  var x = arr;
            ProductList.ItemsSource = arr;
        }
    }
}
