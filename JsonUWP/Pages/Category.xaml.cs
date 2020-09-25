using JsonUWP.Model;
using JsonUWP.Services;
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
    public sealed partial class Category : Page
    {

        private CategoryServices categoryServices = new CategoryServices();
        public Category()
        {
            this.InitializeComponent();

        }
        private MenuItem CatDetail { get; set; }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            MenuItem menuItem = e.Parameter as MenuItem;
            CatDetail = menuItem;
            ButtonBack.IsEnabled = this.Frame.CanGoBack;
            Model.CategoryDetail catDetail = await categoryServices.CategoryDetail(CatDetail.id);
            ProductList.ItemsSource = catDetail.data.foods;
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            if (this.Frame.CanGoBack)
            {
                this.Frame.GoBack();
            }
        }

        private void GridViewItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Product detail = ProductList.SelectedItem as Product;
            MainPage.mainFrame.Navigate(typeof(ProductDetail), detail);
        }

        private ProductServices _productServices = new ProductServices();

        private async void Btn_search_Click(object sender, RoutedEventArgs e)
        {
            List<Product> listSearch = new List<Product>();
            ProductList productList = await _productServices.TodaySpecial();
            if (productList != null)
            {
                foreach (var item in productList.data)
                {
                    if (item.name.Contains(search.Text))
                    {
                        listSearch.Add(item);
                    }
                }
                ProductList.ItemsSource = listSearch;
            }
        }

        private async void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (search.Text == "")
            {
                CategoryDetail catDetail = await categoryServices.CategoryDetail(CatDetail.id);
                ProductList.ItemsSource = catDetail.data.foods;
            }
        }

        private async void FontIconUp_Tapped(object sender, TappedRoutedEventArgs e)
        {
            List<Product> listSearch = new List<Product>();
            CategoryDetail catDetail = await categoryServices.CategoryDetail(CatDetail.id);

            if (catDetail != null)
            {
                foreach (var item in catDetail.data.foods)
                {
                    listSearch.Add(item);
                }
                ProductList.ItemsSource = listSearch.OrderBy(K => K.price).ToList();
            }

        }

        private async void FontIconDown_Tapped(object sender, TappedRoutedEventArgs e)
        {
            List<Product> listSearch = new List<Product>();
            CategoryDetail catDetail = await categoryServices.CategoryDetail(CatDetail.id);

            if (catDetail != null)
            {
                foreach (var item in catDetail.data.foods)
                {
                    listSearch.Add(item);
                }
                ProductList.ItemsSource = listSearch.OrderByDescending(K => K.price).ToList();
            }

        }
    }
}
